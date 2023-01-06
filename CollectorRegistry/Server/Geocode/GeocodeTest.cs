using CollectorRegistry.Server.AppSettings;
using Microsoft.AspNetCore.Mvc;

namespace CollectorRegistry.Server.Geocode
{
    public class GeocodeTest
    {
        private readonly IConfiguration Configuration;
        public GeocodeTest(IConfiguration configuration)
        {
            Configuration = configuration;


        }

        public ContentResult OnGet()
        {
            var geocodeOptions = new GeocodeOptions();
            Configuration.GetSection(geocodeOptions.Geocode).Bind(geocodeOptions);

            //return Content($"Title: {geocodeOptions.Title} \n" +
            //               $"Name: {geocodeOptions.Name}");
        }
    }
}
