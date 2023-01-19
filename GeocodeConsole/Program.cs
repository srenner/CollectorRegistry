// See https://aka.ms/new-console-template for more information
using CollectorRegistry.Shared.Geocode;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Security.Principal;
using System.Text.Json.Serialization;

string BASE_URL = "https://nominatim.openstreetmap.org/search.php";
string CITY_QUERY = "city";
string REGION_QUERY = "state";
string POSTAL_QUERY = "postalcode";
string COUNTRY_QUERY = "country";
string FORMAT_QUERY = "format";

string FORMAT = "jsonv2";
string DEFAULT_COUNTRY = "USA";


Console.WriteLine($"Geocoding service via {BASE_URL}\n");


Console.Write("CITY: ");
string? city = Console.ReadLine();

Console.Write("STATE: ");
string? state = Console.ReadLine();

Console.Write("COUNTRY: ");
string? country = Console.ReadLine();

Console.Write("ZIP: ");
string? postalCode = Console.ReadLine();


var query = new Dictionary<string, string>()
{
    {CITY_QUERY, city },
    {REGION_QUERY, state },
    {COUNTRY_QUERY, (country == null || country.Length == 0) ? DEFAULT_COUNTRY : country },
    {POSTAL_QUERY, postalCode },
    {FORMAT_QUERY, FORMAT }
};

string fullURL = QueryHelpers.AddQueryString(BASE_URL, query);

Console.WriteLine();
Console.WriteLine(fullURL);
Console.WriteLine();

using WebClient client = new WebClient();
client.Headers.Add("user-agent", ".NET 7");

using Stream data = client.OpenRead(fullURL);
using StreamReader reader = new StreamReader(data);
string s = reader.ReadToEnd();

var result = JsonConvert.DeserializeObject<List<GeocodeResult>>(s);

Console.WriteLine(result.ToString());
