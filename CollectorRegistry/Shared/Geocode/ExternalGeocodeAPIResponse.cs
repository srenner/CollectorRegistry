using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CollectorRegistry.Shared.Geocode
{
    public class ExternalGeocodeAPIResponse
    {
        [JsonProperty("lat")]
        public double? GeoLat { get; set; }

        [JsonProperty("lon")]
        public double? GeoLong { get; set; }

        [JsonProperty("display_name")]
        public string? DisplayName { get; set; }
    }
}
