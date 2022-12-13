﻿using CollectorRegistry.Server.AggregatesModel.EntryAggregate;
using CollectorRegistry.Server.Repos;
using CollectorRegistry.Server.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CollectorRegistry.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly IEntryRepository _repo;

        public EntryController(IEntryRepository repo)
        {
            _repo= repo;
        }


        // GET: api/<EntryController>/1/random
        [HttpGet("{siteID}/random")]
        public async Task<Entry> GetRandomEntry(int siteID)
        {
            var svc = new EntryDataService(_repo, siteID);
            return await svc.GetRandomEntry();
        }


        // GET: api/<EntryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EntryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EntryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EntryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EntryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}