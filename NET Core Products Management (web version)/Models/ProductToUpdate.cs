using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_Products_Management__web_version_.Models
{
    public class ProductToUpdate : Product
    {
        [Required]
        public string value { get; set; }
        public string columnName { get; set; }
    }
}
