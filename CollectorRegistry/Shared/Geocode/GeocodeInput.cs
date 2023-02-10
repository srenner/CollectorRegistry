using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.Shared.Geocode
{
    public record struct GeocodeInput
    {
        public int EntryID { get; set; }
        public string? City { get; set; }
        /// <summary>
        /// a.k.a. "State"
        /// </summary>
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

    }
}
