using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class contactsAPI : ControllerBase
    {
        MytaskContext _context;
        public contactsAPI(MytaskContext DBref)
        {
            _context = DBref;
        }

        // GET: api/<contactsAPI>
        [HttpGet]
        public IActionResult Get()
        {
            ////return Ok(_context.User.Include(e => e.Contacts).ToList());
             return Ok(_context.Contacts.ToList());
        }

        // GET api/<contactsAPI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<contactsAPI>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<contactsAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<contactsAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
