using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_Core_Products_Management__web_version_.Models
{
    public class Product
    {
        public int productId { get; set; }
        public string productSymbol { get; set; }
        public string productName { get; set; }
        public decimal productQuantity { get; set; }
        public string productMagName { get; set; }
    }
}
