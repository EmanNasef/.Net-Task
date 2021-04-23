using Microsoft.AspNetCore.Mvc;
using MyTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class calenderAPI : ControllerBase
    {
        MytaskContext _context;
        public calenderAPI(MytaskContext cxt)
        {
            _context = cxt;
        }

        // GET: api/<calenderAPI>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Calender.ToList());
        }

        // GET api/<calenderAPI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<calenderAPI>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<calenderAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<calenderAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
