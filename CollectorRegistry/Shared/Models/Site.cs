using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.Shared.Models
{
    public class Site
    {
        public int SiteID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AboutText { get; set; }
        public string Subdomain { get; set; }
        public string Logo { get; set; }
        public string? VinRegex { get; set; }
    }
}
