using System;
using System.Collections.Generic;

namespace NET_Core_Products_Management__web_version_.Models
{
    public partial class SlMagazyn
    {
        public int MagId { get; set; }
        public string MagSymbol { get; set; }
        public string MagNazwa { get; set; }
        public int MagStatus { get; set; }
        public string MagOpis { get; set; }
        public string MagAnalityka { get; set; }
        public bool MagGlowny { get; set; }
        public bool MagPos { get; set; }
        public Guid? MagPosident { get; set; }
        public string MagPosnazwa { get; set; }
        public string MagPosadres { get; set; }
    }
}
