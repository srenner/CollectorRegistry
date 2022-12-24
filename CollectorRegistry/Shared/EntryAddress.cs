using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.Shared
{
    [Serializable]
    public class EntryAddress
    {
        public int EntryID { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        public decimal? GeoLat { get; set; }
        public decimal? GeoLong { get; set; }
    }
}
