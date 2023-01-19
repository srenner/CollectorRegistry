using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.Geocode
{
    public class GeocodeService
    {
        private const string BASE_URL = "https://nominatim.openstreetmap.org/search.php";
        private const string CITY_QUERY = "city";
        private const string REGION_QUERY = "state";
        private const string POSTAL_QUERY = "postalcode";
        private const string COUNTRY_QUERY = "country";
        private const string FORMAT_QUERY = "format";

        private const string FORMAT = "jsonv2";
        private const string DEFAULT_COUNTRY = "USA";


        public GeocodeService()
        {

        }

        public void Fetch(string? city = null, string? state = null, string? postalCode = null, string? country = DEFAULT_COUNTRY)
        {
            var query = new Dictionary<string, string>()
{
                {CITY_QUERY, city },
                {REGION_QUERY, state },
                {COUNTRY_QUERY, (country == null || country.Length == 0) ? DEFAULT_COUNTRY : country },
                {POSTAL_QUERY, postalCode },
                {FORMAT_QUERY, FORMAT }
            };
            string fullURL = QueryHelpers.AddQueryString(BASE_URL, query);

        }
    }
}
