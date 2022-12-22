using CollectorRegistry.Server.AggregatesModel.EntryAggregate;
using CollectorRegistry.Server.AggregatesModel.ItemAggregate;

namespace CollectorRegistry.Server.AggregatesModel.SiteAggregate
{
    public class Site : IAggregateRoot
    {
        public int SiteID { get; set; }

        #region required
        /// <summary>
        /// Main heading for the site
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Used for the site URL
        /// </summary>
        public string Subdomain { get; set; }
        #endregion

        #region optional
        /// <summary>
        /// Short decision for the site's main page
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Longer version of description for an "About" type of page
        /// </summary>
        public string? AboutText { get; set; }
        public string? Logo { get; set; }
        [Obsolete("Not currently implemented; use MinLength, MaxLength, StartsWith, EndsWith instead", true)]
        public string? SerialNumberRegex { get; set; }
        
        public int? SerialNumberMinLength { get; set; }
        public int? SerialNumberMaxLength { get; set; }
        public string? SerialNumberStartsWith { get; set; }
        public string? SerialNumberEndsWith { get; set; }

        public string? SerialNumberLabel { get; set; } = "VIN";
        public string? SerialNumberHint { get; set; }
        public string? PrimaryColor { get; set; } = "#202A44";
        public string? SecondaryColor { get; set; } = "#45411D";

        /// <summary>
        /// How to refer to a generic version of an item, e.g. "car" or "Goldwing"
        /// </summary>
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
