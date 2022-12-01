using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.Shared.Models
{
    public class Entry
    {
        public int EntryID { get; set; }

        public int SiteID { get; set; }
        
        public Site Site { get; set; }

        [DefaultValue(true)]
        public bool OnRoad { get; set; }
        
        [DefaultValue(false)]
        public bool Deceased { get; set; }
        
        [DefaultValue(false)]
        public bool ForSale { get; set; }

        public decimal? ListPrice { get; set; }

        public decimal? TransactionPrice { get; set; }





        public string? Owner { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        public int? Mileage { get; set; }
        public string? Comments { get; set; }


        public DateTime EntryDateTime { get; set; }
        public DateTime ActualEntryDateTime { get; set; }


        [DefaultValue(false)]
        public bool IsDeleted { get; set; }


    }
}
