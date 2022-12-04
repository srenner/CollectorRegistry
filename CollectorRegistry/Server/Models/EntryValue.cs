namespace CollectorRegistry.Server.Models
{
    public class EntryValue
    {
        public int EntryValueID { get; set; }

        public int EntryDefinitionID { get; set; }
        public EntryDefinition EntryDefinition { get; set; }

        public string? Value { get; set; }
    }
}
