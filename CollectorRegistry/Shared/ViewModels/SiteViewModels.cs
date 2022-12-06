using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.Shared.ViewModels
{
    public class SiteViewModel
    {
        public int SiteID { get; set; }
        public string Title { get; set; }
        public string Subdomain { get; set; }
        public string? Description { get; set; }
        public string? AboutText { get; set; }
        public string? Logo { get; set; }
        public string? SerialNumberRegex { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        
        //item viewmodel collection
        //entry definition viewmodel collection
    }
}
