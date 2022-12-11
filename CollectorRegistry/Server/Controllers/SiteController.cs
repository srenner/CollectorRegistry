using CollectorRegistry.Server.AggregatesModel.SiteAggregate;
using CollectorRegistry.Server.Repos;
using CollectorRegistry.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CollectorRegistry.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        private readonly IGenericRepository _repo;

        public SiteController(IGenericRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<SiteController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Site>> Get()
        {
            return await _repo.GetAllEntities<Site>();
        }

        // GET api/<SiteController>/5
        [HttpGet("{id}")]
        public async Task<Site> Get(int id)
        {
            return await _repo.GetEntity<Site>(id);
        }

        // POST api/<SiteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<SiteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<SiteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
