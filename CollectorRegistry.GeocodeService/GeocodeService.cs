using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;

namespace CollectorRegistry.GeocodeService
{
    public class GeocodeService
    {
        private string _baseURL = "https://nominatim.openstreetmap.org/search.php";
        private string _cityQuery = "city";
        private string _regionQuery = "state";
        private string _postalQuery = "postalcode";
        private string _countryQuery = "country";
        private string _formatQuery = "format";
        private string _format = "jsonv2";
        
        private const string DEFAULT_COUNTRY = "USA";
        
        private IOptions<GeocodeSettings> _settings;

        public GeocodeService(IOptions<GeocodeSettings> settings)
        {
            _settings = settings;
        }

        public void Run()
        {
            BuildURL();
        }

        private string GetCoordinates(string url)
        {
            return "";
        }
        private string BuildURL(string? city = null, string? state = null, string? postalCode = null, string? country = DEFAULT_COUNTRY)
        {
            var query = new Dictionary<string, string>()
            {
                {_cityQuery, city },
                {_regionQuery, state },
                {_countryQuery, (country == null || country.Length == 0) ? DEFAULT_COUNTRY : country },
                {_postalQuery, postalCode },
                {_formatQuery, _format }
            };
            
            string fullURL = QueryHelpers.AddQueryString(_baseURL, query);
            return fullURL;
        }
    }
}
