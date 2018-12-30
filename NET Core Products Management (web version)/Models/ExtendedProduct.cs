using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_Core_Products_Management__web_version_.Models
{
    public class ExtendedProduct
    {
        [Required]
        public string tw_Nazwa { get; set; }
        [Required]
        public string tw_Symbol { get; set; }
        [Required]
        public string tw_JednMiary { get; set; }
        [Required]
        public string tw_UrzNazwa { get; set; }
        [Required]
        public string tw_JednMiaryZak { get; set; }
        [Required]
        public string tw_JednMiarySprz { get; set; }
        [RegularExpression("([0-9,.]+)")]
        [Required]
        public decimal st_Stan { get; set; }
        public string mag_Symbol { get; set; }
        public string mag_Nazwa { get; set; }
        public bool tw_Zablokowany { get; set; }
        public readonly List<string> Warehouses = new List<string>();
    }
}
