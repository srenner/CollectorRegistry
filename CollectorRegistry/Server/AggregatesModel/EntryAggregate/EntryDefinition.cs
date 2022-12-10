using CollectorRegistry.Server.AggregatesModel.SiteAggregate;

namespace CollectorRegistry.Server.AggregatesModel.EntryAggregate
{
    public class EntryDefinition
    {
        public int EntryDefinitionID { get; set; }

        public int SiteID { get; set; }
        public Site Site { get; set; }

        public string Label { get; set; }

        public int SortOrder { get; set; }

        public List<EntryDefinitionOption> Options { get; set; }
    }
}
