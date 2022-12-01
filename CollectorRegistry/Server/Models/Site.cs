namespace CollectorRegistry.Server.Models
{
    public class Site
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
        public string? VinRegex { get; set; }
        #endregion


        #region meta

        public DateTime CreationDate { get; set; }
        public bool IsApproved { get;set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get;set; }

        #endregion

    }


}
