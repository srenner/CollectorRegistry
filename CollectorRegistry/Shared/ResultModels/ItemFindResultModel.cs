using CollectorRegistry.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.Shared.ResultModels
{
    public class ItemFindResultModel
    {
        public bool IsFound { get; set; }
        public bool IsPatternMatch { get; set; }
        public string SearchText { get; set; }
        public ItemViewModel? Item { get; set; }
    }
}
