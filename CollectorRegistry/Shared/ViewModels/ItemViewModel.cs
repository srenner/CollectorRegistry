using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.Shared.ViewModels
{
    public class ItemViewModel
    {
        public int ItemID { get; set; }
        public int SiteID { get; set; }
        public string SerialNumber { get; set; }
        public string? Comment { get; set; }

        public List<EntryViewModel> Entries { get; set; }
    }
}
