namespace CollectorRegistry.Server.Models
{
    public class Item
    {
        public int ItemID { get; set; }

        public int SiteID { get; set; }
        public Site Site { get; set; }

        public string SerialNumber { get; set; }
        public string? Comment { get; set; }

        public List<Entry> Entries { get; set; }
    }
}
