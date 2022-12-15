using CollectorRegistry.Server.AggregatesModel.ItemAggregate;
using CollectorRegistry.Shared.ViewModels;

namespace CollectorRegistry.Server.ModelExtensions
{
    public static class ItemExtensions
    {
        public static ItemViewModel ToViewModel(this Item item)
        {
            var vm = new ItemViewModel();

            vm.Comment = item.Comment;
            vm.ItemID = item.ItemID;
            vm.SerialNumber = item.SerialNumber;
            vm.SiteID = item.SiteID;

            return vm;
        }
    }
}
