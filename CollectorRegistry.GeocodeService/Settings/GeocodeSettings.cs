﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.GeocodeService.Settings
{
    public class GeocodeSettings : IOptions<GeocodeSettings>
    {
        public string BaseURL { get; set; }
        public string CityQuery { get; set; }
        public string RegionQuery { get; set; }
        public string PostalQuery { get; set; }
        public string CountryQuery { get; set; }
        public string FormatQuery { get; set; }
        public string Format { get; set; }
        public string DefaultCountry { get; set; }
        public int RateLimitMillis { get; set; }

        //public GeocodeSettings Value => throw new NotImplementedException();
        public GeocodeSettings Value { get { return this; } }
    }
}
