using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_Products_Management__web_version_.Models
{
    public interface IProductRepository : IDisposable
{
        List<Product> LoadProducts();
        bool UpdateProductProperty(string columnName, int id, string value, string warehouseName);
        bool CreateNewProduct(ExtendedProduct product);
        void RemoveProducts(List<int> productsIds);
        bool RemoveProducts(int id);
        List<string> GetWarehousesNames();
        string GetWarehouseSymbol(string wName);
    }
}
