﻿namespace CollectorRegistry.Server.Models
{
    public class EntryDefinition
    {
        public int EntryDefinitionID { get; set; }

        public int SiteID { get; set; }
        public Site Site { get; set; }

        public string Label { get; set; }

        public int SortOrder { get; set; }
    }
}
