using CollectorRegistry.Server.AggregatesModel.ItemAggregate;
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
        private readonly IItemRepository _repo;

        public ItemController(IItemRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<ItemController>/siteID/find/searchText
        [HttpGet("{siteID}/find/{searchText}")]
        public async Task<ItemFindResultModel> FindBySerialNumber(int siteID, string searchText)
        {
            var svc = new ItemDataService(_repo, siteID);
            var result = await svc.FindItemBySerialNumber(searchText);
            return result;
        }

        // GET: api/<ItemController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ItemController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
