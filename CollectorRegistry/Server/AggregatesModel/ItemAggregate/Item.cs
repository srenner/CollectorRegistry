using CollectorRegistry.Server.AggregatesModel.EntryAggregate;
using CollectorRegistry.Server.AggregatesModel.SiteAggregate;

namespace CollectorRegistry.Server.AggregatesModel.ItemAggregate
{
    public class Item : IAggregateRoot
    {
        public int ItemID { get; set; }

        public int SiteID { get; set; }
        public Site Site { get; set; }

        public string SerialNumber { get; set; }
        public string? Comment { get; set; }

        public List<Entry> Entries { get; set; }
    }
}
