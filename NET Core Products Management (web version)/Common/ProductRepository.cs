using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_Products_Management__web_version_.Models
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private ProductsContext ctx;
        public ProductRepository(ProductsContext context)
        {
            ctx = context;
        }
        public List<Product> LoadProducts()
        {
            DbSet<TwTowar> towary = ctx.TwTowar;
            DbSet<TwStan> stany = ctx.TwStan;
            DbSet<SlMagazyn> magazyny = ctx.SlMagazyn;
            var query = magazyny.SelectMany(magazyn => towary.SelectMany(towar => stany
            .Where(stan => stan.StTowId == towar.TwId)
            .Where(stan => stan.StMagId == magazyn.MagId)
            .Select(stan => new Product
            {
                productId = towar.TwId,
                productSymbol = towar.TwSymbol,
                productName = towar.TwNazwa,
                productQuantity = stan.StStan,
                productMagName = magazyn.MagNazwa
            }).ToList()));
            return new List<Product>(query);
        }
        public bool UpdateProductProperty<T>(string columnName, int id, T value, int warehouseId)
        {
            switch (columnName)
            {
                case "productSymbol":
                    ctx.TwTowar.Where(towar => towar.TwId == id)
                        .First().TwSymbol = Convert.ToString(value).ToUpper();
                    break;
                case "productName":
                    ctx.TwTowar.Where(towar => towar.TwId == id)
                        .First().TwNazwa = Convert.ToString(value);
                    break;
                case "productQuantity":
                    //ctx.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                    var query = ctx.TwStan.Where(stan => stan.StTowId == id && stan.StMagId == warehouseId)
                        .First().StStan = Convert.ToDecimal(value);
                    break;
                default:
                    return false;
            }
            ctx.SaveChanges();
            return true;
        }
        public bool CreateNewProduct(ExtendedProduct product)
        {
            int magId = int.MinValue;
            if (ctx.SlMagazyn
            .Where(magazyn => magazyn.MagNazwa.Equals(product.mag_Nazwa) || magazyn.MagSymbol.Equals(product.mag_Symbol))
            .FirstOrDefault() == null)
            {
                int newmagId = ctx.SlMagazyn.Select(magazyn => magazyn.MagId).Max() + 1;
                magId = newmagId;
                ctx.SlMagazyn.Add(new SlMagazyn
                {
                    MagId = newmagId,
                    MagNazwa = product.mag_Nazwa,
                    MagSymbol = product.mag_Symbol
                });
            }
            else
                magId = ctx.SlMagazyn.Where(magazyn => magazyn.MagNazwa.Equals(product.mag_Nazwa)
            && magazyn.MagSymbol.Equals(product.mag_Symbol)).First().MagId;
            ctx.SaveChanges();
            int newtwId = ctx.TwTowar.Select(towar => towar.TwId).Max() + 1;
            ctx.TwTowar.Add(new TwTowar
            {
                TwId = newtwId,
                TwZablokowany = product.tw_Zablokowany,
                TwSymbol = product.tw_Symbol.ToUpper(),
                TwNazwa = product.tw_Nazwa,
                TwJednMiary = product.tw_JednMiary,
                TwUrzNazwa = product.tw_UrzNazwa,
                TwJednMiaryZak = product.tw_JednMiaryZak,
                TwJednMiarySprz = product.tw_JednMiarySprz
            });
            ctx.SlMagazyn.ForEachAsync(magazyn => ctx.TwStan.Add(new TwStan
            {
                StTowId = newtwId,
                StStan = 0,
                StMagId = magazyn.MagId
            }));
            ctx.SaveChanges();
            //int newtwId = ctx.tw__Towar.Select(towar => towar.tw_Id).Max() + 1;
            ctx.TwStan.Where(stan => stan.StTowId == newtwId && stan.StMagId == magId).First()
                .StStan = product.st_Stan;
            ctx.SaveChanges();
            return true;
        }
        public void RemoveProducts(List<int> productsIds)
        {
            productsIds.ForEach(i => ctx.TwTowar.Remove(ctx.TwTowar.Where(towar => towar.TwId == i).First()));
            productsIds.ForEach(i => ctx.TwStan.Remove(ctx.TwStan.Where(stan => stan.StTowId == i).First()));
            ctx.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    ctx.Dispose();                
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
