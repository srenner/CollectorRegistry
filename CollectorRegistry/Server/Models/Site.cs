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
    }
}
