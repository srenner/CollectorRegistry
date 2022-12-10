using CollectorRegistry.Server.AggregatesModel.EntryAggregate;
using CollectorRegistry.Server.AggregatesModel.ItemAggregate;

namespace CollectorRegistry.Server.AggregatesModel.SiteAggregate
{
    public class Site : IAggregateRoot
    {
        public int SiteID { get; set; }

        #region required
        public string Title { get; set; }
        public string Subdomain { get; set; }
        #endregion

        #region optional
        public string? Description { get; set; }
        public string? AboutText { get; set; }
        public string? Logo { get; set; }
        public string? SerialNumberRegex { get; set; }
        public string? SerialNumberLabel { get; set; }
        #endregion


        #region meta

        public DateTime CreationDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        #endregion


        #region collections

        public List<Item>? Items { get; set; }
        public List<EntryDefinition>? EntryDefinitions { get; set; }

        #endregion
    }


}
