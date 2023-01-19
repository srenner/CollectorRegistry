using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CollectorRegistry.Shared.Geocode
{
    public class GeocodeResult
    {
        [JsonProperty("lat")]
        public decimal? GeoLat { get; set; }

        [JsonProperty("lon")]
        public decimal? GeoLong { get; set; }

        [JsonProperty("display_name")]
        public string? DisplayName { get; set; }
    }
}
