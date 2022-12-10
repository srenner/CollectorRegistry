namespace CollectorRegistry.Server.AggregatesModel.EntryAggregate
{
    public class EntryDefinitionOption
    {
        public int EntryDefinitionOptionID { get; set; }

        public int EntryDefinitionID { get; set; }
        public EntryDefinition EntryDefinition { get; set; }

        public string Value { get; set; }
        public int SortOrder { get; set; }
    }
}
