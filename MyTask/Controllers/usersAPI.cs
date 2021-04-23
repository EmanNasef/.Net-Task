using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersAPI : ControllerBase
    {
        // GET: api/<usersAPI>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<usersAPI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<usersAPI>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<usersAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<usersAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
