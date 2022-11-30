using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.Shared.Models
{
    public class Entry
    {
        public int EntryID { get; set; }

        public int SiteID { get; set; }
        public Site Site { get; set; }

        [DefaultValue(true)]
        public bool OnRoad { get; set; }
        
        [DefaultValue(false)]
        public bool Deceased { get; set; }
    }
}
