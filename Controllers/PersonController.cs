using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_TDPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_TDPC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet("Get")]
        public async Task<Person> Get()
        {
            Person person = new Person()
            {
                ID = Guid.NewGuid(),
                Nome = "Dante",
                Cognome = "Alighieri"
            };
            return person;
        }
        // POST api/<PersonController>
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            if (person != null)
            {
                person.Nome = person.Nome + " NEW";
                person.Cognome = person.Cognome + " NEW";
            }
            return Ok(person);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] Person person)
        {
            if (person != null)
            {
                person.Nome = person.Nome + " NEW";
                person.Cognome = person.Cognome + " NEW";
            }
            return Ok(person);
        }
    }
}