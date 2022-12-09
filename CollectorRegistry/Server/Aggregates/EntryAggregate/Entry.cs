using CollectorRegistry.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using CollectorRegistry.Server.Aggregates.ItemAggregate;

namespace CollectorRegistry.Server.Aggregates.EntryAggregate
{
    public class Entry
    {
        public int EntryID { get; set; }

        public int ItemID { get; set; }
        [Required]
        public Item Item { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [DefaultValue(false)]
        public bool Deceased { get; set; }

        [DefaultValue(false)]
        public bool ForSale { get; set; }

        [Precision(12, 2)]
        public decimal? ListPrice { get; set; }

        [Precision(12, 2)]
        public decimal? TransactionPrice { get; set; }



        public string? Owner { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        [Precision(10, 8)]
        public decimal? GeoLat { get; set; }

        [Precision(11, 8)]
        public decimal? GeoLong { get; set; }

        public int? Mileage { get; set; }
        public string? Comments { get; set; }


        public DateTime EntryDateTime { get; set; }
        public DateTime ActualEntryDateTime { get; set; }
        public string? EntryIP { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }


        public List<EntryValue> EntryValues { get; set; }
    }
}
