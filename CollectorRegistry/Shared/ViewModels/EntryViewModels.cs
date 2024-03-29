﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.Shared.ViewModels
{
    public class EntryViewModel
    {
        public int EntryID { get; set; }

        public int SiteID { get; set; }

        public SiteViewModel Site { get; set; }

        public int ItemID { get; set; }

        [DefaultValue(true)]
        public bool OnRoad { get; set; }
        
        [DefaultValue(false)]
        public bool Deceased { get; set; }
        
        [DefaultValue(false)]
        public bool ForSale { get; set; }

        public decimal? ListPrice { get; set; }

        public decimal? TransactionPrice { get; set; }



        public string? SerialNumber { get; set; }


        public string? Owner { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public double? GeoLat { get; set; }
        public double? GeoLong { get; set; }
        public string GeoDescription { get; set; }

        public int? Mileage { get; set; }
        public string? Comments { get; set; }


        public DateTime EntryDateTime { get; set; }
        public DateTime ActualEntryDateTime { get; set; }
        
        //removed for security/privacy
        //access the full Entry entity for this info
        //public string? EntryIP { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }


    }
}
