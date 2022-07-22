using Microsoft.AspNetCore.Mvc;
using MVC_TDPC.DB;
using MVC_TDPC.DB.Entities;
using MVC_TDPC.Models;
using System.Threading.Tasks;

namespace MVC_TDPC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly Repository repository;
        public PersonController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpPost("InsertPerson")]
        public async Task<IActionResult> InsertPerson([FromBody] PersonModel model)
        {
            Person person = new Person();
            person.Nome = model.Nome;
            person.Cognome = model.Cognome;
            this.repository.InsertPerson(person);
            return Ok(200);
        }

        [HttpPost("UpdatePerson")]
        public async Task<IActionResult> UpdatePerson([FromBody] PersonModel model)
        {
            Person person = new Person();
            person.ID = System.Guid.Parse(model.ID);
            person.Nome = model.Nome;
            person.Cognome = model.Cognome;
            this.repository.UpdatePerson(person);
            return Ok(200);
        }

        [HttpPost("DeletePerson")]
        public async Task<IActionResult> DeletePerson([FromBody] PersonModel model)
        {
            this.repository.DeletePerson(model.ID);
            return Ok(200);
        }
    }
}