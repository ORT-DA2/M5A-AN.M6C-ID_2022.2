using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Logic;
using Logic.Interface;
using Domain;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/people")]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonLogic personLogic;
        public PeopleController(IPersonLogic personLogic)
        {
            this.personLogic = personLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(personLogic.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Person person = personLogic.GetById(id);

            if (person != null) return Ok(person);
            else return NotFound("No se encontro persona de id: " + id);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            return Created("Creado exitoso", person);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Person person)
        {
            return Ok($"Se modifico a la persona de id: {id}");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Se elimino a la persona de id: {id}");
        }
        [HttpGet("example")]
        public IActionResult GetByName([FromQuery] string name)
        {
            if (name == null) return BadRequest("Debe ingresar un nombre");
            return Ok(personLogic.GetByName(name));

        }
    }
}
