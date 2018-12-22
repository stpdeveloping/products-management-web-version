using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_Products_Management__web_version_.Models
{
    public interface IProductRepository : IDisposable
{
        List<Product> LoadProducts();
        bool UpdateProductProperty<T>(string columnName, int id, T value, int warehouseId);
        bool CreateNewProduct(ExtendedProduct product);
        void RemoveProducts(List<int> productsIds);
    }
}
