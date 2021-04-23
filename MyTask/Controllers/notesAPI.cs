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
    public class notesAPI : ControllerBase
    {
        MytaskContext _context;
        public notesAPI(MytaskContext DBref)
        {
            _context = DBref;
        }

        // GET: api/<notesAPI>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Notes.ToList());
        }

        // GET api/<notesAPI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<notesAPI>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<notesAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<notesAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
