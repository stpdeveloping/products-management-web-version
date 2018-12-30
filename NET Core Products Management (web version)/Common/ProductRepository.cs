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
        public bool UpdateProductProperty(string columnName, int id, string value, string warehouseName)
        {
            int warehouseId = ctx.SlMagazyn.Where(mag => mag.MagNazwa == warehouseName).ToList().First().MagId;
            switch (columnName)
            {
                case "pSymbol":
                    ctx.TwTowar.Where(towar => towar.TwId == id)
                        .First().TwSymbol = value.ToUpper();
                    break;
                case "pName":
                    ctx.TwTowar.Where(towar => towar.TwId == id)
                        .First().TwNazwa = value;
                    break;
                case "pQuantity":
                    //ctx.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                    var query = ctx.TwStan.Where(stan => stan.StTowId == id && stan.StMagId == warehouseId).ToList()
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
            .ToList()
            .FirstOrDefault() == null)
            {
                int newmagId = ctx.SlMagazyn.Select(magazyn => magazyn.MagId).ToList().Max() + 1;
                magId = newmagId;
                ctx.SlMagazyn.Add(new SlMagazyn
                {
                    MagId = newmagId,
                    MagNazwa = product.mag_Nazwa,
                    MagSymbol = product.mag_Symbol
                });
                ctx.TwStan.Select(st => st.StTowId).Distinct()
                            .ToList().ForEach(i => ctx.TwStan.Add(new TwStan
                            {
                                StTowId = i,
                                StMagId = newmagId,
                                StStan = 0
                            }));
            }
            else
                magId = ctx.SlMagazyn.Where(magazyn => magazyn.MagNazwa.Equals(product.mag_Nazwa)
            && magazyn.MagSymbol.Equals(product.mag_Symbol)).ToList().First().MagId;
            ctx.SaveChanges();
            int newtwId = ctx.TwTowar.Select(towar => towar.TwId).ToList().Max() + 1;
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
            ctx.TwStan.Where(stan => stan.StTowId == newtwId && stan.StMagId == magId).First()
                .StStan = product.st_Stan;
            ctx.SaveChanges();
            return true;
        }
        public void RemoveProducts(List<int> productsIds)
        {
            productsIds.ForEach(i => ctx.TwTowar.Remove(ctx.TwTowar.Where(towar => towar.TwId == i).ToList().First()));
            productsIds.ForEach(i => ctx.TwStan.Remove(ctx.TwStan.Where(stan => stan.StTowId == i).ToList().First()));
            ctx.SaveChanges();
        }
        public bool RemoveProducts(int id)
        {
            if (ctx.TwTowar.Where(towar => towar.TwId == id).ToList().FirstOrDefault() == null)
                return false;
            ctx.TwTowar.Remove(ctx.TwTowar.Where(towar => towar.TwId == id).ToList().First());
            ctx.TwStan.Remove(ctx.TwStan.Where(stan => stan.StTowId == id).ToList().First());
            ctx.SaveChanges();
            return true;
        }
        public List<string> GetWarehousesNames()
        {
            return ctx.SlMagazyn.Select(mag => mag.MagNazwa).ToList();
        }
        public string GetWarehouseSymbol(string wName)
        {
            return ctx.SlMagazyn.Where(mag => mag.MagNazwa == wName).ToList().First().MagSymbol;
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
