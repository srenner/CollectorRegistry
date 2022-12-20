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
        
        public int? SerialNumberMinLength { get; set; }
        public int? SerialNumberMaxLength { get; set; }
        public string? SerialNumberStartsWith { get; set; }
        public string? SerialNumberEndsWith { get; set; }
        
        public string? SerialNumberLabel { get; set; }
        public string? SerialNumberHint { get; set; }
        public string? PrimaryColor { get; set; } = "#202A44";
        public string? SecondaryColor { get; set; } = "#45411D";


        public string? ItemNickname { get; set; } = "item";

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



        public bool IsSerialNumberValid(string searchText)
        {
            if (searchText == null || searchText.Trim().Length == 0) { return false; }
            if (SerialNumberMinLength.HasValue && searchText.Length < SerialNumberMinLength) { return false; }
            if (SerialNumberMaxLength.HasValue && searchText.Length > SerialNumberMaxLength) { return false; }
            if (SerialNumberStartsWith != null)
            {
                if (!searchText.StartsWith(SerialNumberStartsWith)) { return false; }
            }
            if (SerialNumberEndsWith != null)
            {
                if (!searchText.EndsWith(SerialNumberEndsWith)) { return false; }
            }

            return true;
        }



    }


}
