using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicePro.API.Controllers.Invoice
{
    [Route("api/[controller]")]
    [ApiController]
    public class Invoice : ControllerBase
    {
        // GET: api/<Invoice>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Invoice>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Invoice>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Invoice>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Invoice>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
