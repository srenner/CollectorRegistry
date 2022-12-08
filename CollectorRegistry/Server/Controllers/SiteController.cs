using CollectorRegistry.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CollectorRegistry.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        // GET: api/<SiteController>
        [HttpGet]
        public IEnumerable<SiteViewModel> Get()
        {
            //return new string[] { "value1", "value2" };
            throw new NotImplementedException();
        }

        // GET api/<SiteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<SiteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SiteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SiteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
