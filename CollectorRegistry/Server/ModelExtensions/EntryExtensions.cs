using CollectorRegistry.Server.AggregatesModel.EntryAggregate;
using CollectorRegistry.Shared.ViewModels;

namespace CollectorRegistry.Server.ModelExtensions
{
    public static class EntryExtensions
    {
        public static EntryViewModel ToViewModel(this Entry entry)
        {
            var vm = new EntryViewModel();

            vm.ActualEntryDateTime = entry.ActualEntryDateTime;
            vm.City = entry.City;
            vm.Comments = entry.Comments;
            vm.Country = entry.Country;
            vm.Deceased = entry.Deceased;
            vm.EntryDateTime = entry.EntryDateTime;
            vm.EntryID = entry.EntryID;
            vm.ForSale = entry.ForSale;
            vm.GeoLat = entry.GeoLat;
            vm.GeoLong = entry.GeoLong;
            vm.IsDeleted = entry.IsDeleted;
            vm.ItemID = entry.ItemID;
            vm.ListPrice = entry.ListPrice;
            vm.Mileage = entry.Mileage;
            //vm.OnRoad = //not implemented in base class yet
            vm.Owner = entry.Owner;
            vm.PostalCode = entry.PostalCode;
            vm.Region = entry.Region;
            vm.SiteID = entry.Item?.SiteID ?? 0;
            vm.TransactionPrice = entry.TransactionPrice;
            return vm;
        }

        public static List<EntryViewModel> ToViewModel(this List<Entry> entries)
        {
            var vm = new List<EntryViewModel>();
            entries.ForEach(x => vm.Add(ToViewModel(x)));
            return vm;
        }
    }
}
