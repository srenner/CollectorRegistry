namespace CollectorRegistry.Server.AppSettings
{
    //options pattern: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-7.0
    public class GeocodeOptions
    {
        public string Geocode = "Geocode";

        public string BaseURL { get; set; } = String.Empty;
        public string CityQuery { get; set; } = String.Empty;
        public string RegionQuery { get; set; } = String.Empty;
        public string PostalQuery { get; set; } = String.Empty;
        public string CountryQuery { get; set; } = String.Empty;
    }





}
