using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CollectorRegistry.GeocodeService.Settings;
using CollectorRegistry.Shared.Geocode;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CollectorRegistry.GeocodeService
{
    public class GeocodeService
    {
        private IOptions<GeocodeSettings> _settings;

        public GeocodeService(IOptions<GeocodeSettings> settings)
        {
            _settings = settings;
        }

        public async Task<List<GeocodeResult>> Run(string? city, string? state, string? postalCode, string? country)
        {
            var url = BuildURL(city, state, postalCode, country);
            return await GetCoordinates(url);
        }

        private async Task<List<GeocodeResult>> GetCoordinates(string url)
        {

            HttpClient httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.UserAgent.Add(new ProductInfoHeaderValue(".NET", "7.0"));
            var response = await httpClient.SendAsync(request);
            var txt = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<GeocodeResult>>(txt);
        }

        private string BuildURL(string? city, string? state, string? postalCode, string? country)
        {
            var query = new Dictionary<string, string>()
            {
                {_settings.Value.CityQuery, city },
                {_settings.Value.RegionQuery, state },
                {_settings.Value.CountryQuery, (country == null || country.Length == 0) ? _settings.Value.DefaultCountry : country },
                {_settings.Value.PostalQuery, postalCode },
                {_settings.Value.FormatQuery, _settings.Value.Format }
            };
            
            string fullURL = QueryHelpers.AddQueryString(_settings.Value.BaseURL, query);
            Console.WriteLine(fullURL);
            return fullURL;
        }
    }
}
