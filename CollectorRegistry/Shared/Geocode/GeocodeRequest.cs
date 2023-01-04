using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.Shared.Geocode
{
    public class GeocodeRequest
    {
        public static string BASE_URL = "https://nominatim.openstreetmap.org/search.php";
        public static string CITY_QUERY = "city";
        public static string REGION_QUERY = "state";
        public static string POSTAL_QUERY = "postalcode";
        public static string COUNTRY_QUERY = "country";

        public int EntryID { get; }

        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        public GeocodeRequest(int entryID)
        {
            this.EntryID = entryID;
        }

        
    }
}
