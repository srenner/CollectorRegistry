using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.Shared.MessageRecords
{
    public record struct GeocodeOutput
    {
        public int EntryID { get; set; }
        public double? GeoLat { get; set; } 
        public double? GeoLong { get; set; } 
        public string GeoDescription { get; set; }
    }
}
