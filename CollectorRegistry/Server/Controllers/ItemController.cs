using CollectorRegistry.Server.AggregatesModel.ItemAggregate;
using CollectorRegistry.Server.ModelExtensions;
using CollectorRegistry.Server.RegistryAggregate;
using CollectorRegistry.Server.Repos;
using CollectorRegistry.Server.Services;
using CollectorRegistry.Shared.ResultModels;
using CollectorRegistry.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CollectorRegistry.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepo;
        private readonly ISiteRepository _siteRepo;

        public ItemController(IItemRepository repo, ISiteRepository siteRepo)
        {
            _itemRepo = repo;
            _siteRepo = siteRepo;
        }

        // GET: api/<ItemController>/siteID/find/searchText
        [HttpGet("{siteID}/find/{searchText}")]
        public async Task<ItemFindResultModel> FindBySerialNumber(int siteID, string searchText)
        {
            var result = new ItemFindResultModel();
            var svc = new ItemDataService(_itemRepo, siteID);
            var item = await svc.FindItemBySerialNumber(searchText);
            if(item != null)
            {
                result.IsFound = true;
                result.IsPatternMatch = true;
                result.Item = item.ToViewModel();
            }
            else
            {
                var siteService = new SiteDataService(_siteRepo);

                var site = await siteService.GetSite(siteID);

                result.IsFound = false;
                result.IsPatternMatch = site.IsSerialNumberValid(searchText);
            }

            return result;
        }


        // GET: api/<ItemController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public async Task<ItemViewModel> Get(int id)
        {
            var svc = new ItemDataService(_itemRepo);
            var item = await svc.GetItemByID(id);
            return item.ToViewModel();
        }

        // POST api/<ItemController>
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] ItemViewModel item)
        {
            if(item.SiteID > 0)
            {
                var svc = new ItemDataService(_itemRepo, item.SiteID);
                var newItem = await svc.AddItem(item.SerialNumber);
                return new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent(newItem.ItemID.ToString())
                };
            }
            else
            {
                return new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Content = new StringContent("SiteID not found in request")
                };
            }
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
