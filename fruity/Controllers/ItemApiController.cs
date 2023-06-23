using Domains;
using fruity.BI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fruity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemApiController : ControllerBase
    {
        IItemservice Itemservice;
        public ItemApiController(IItemservice itemservice)
        {
            Itemservice = itemservice;
        }
        // GET: api/<ItemApiController>
        [HttpGet]
        public IEnumerable<VwItemCategory> Get()
        {
            List<VwItemCategory> lisvwItemCategory = Itemservice.GetAllApi();
            return lisvwItemCategory;
        }

        // GET api/<ItemApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ItemApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ItemApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
