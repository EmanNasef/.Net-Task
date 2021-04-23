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
    public class tasksAPI : ControllerBase
    {
        MytaskContext _context;
        public tasksAPI(MytaskContext cxt)
        {
            _context = cxt;
        }

        // GET: api/<tasksAPI>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Tasks.ToList());
        }

        // GET api/<tasksAPI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<tasksAPI>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<tasksAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<tasksAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
