using JMComercialWebApi.Data;
using JMComercialWebApi.Models.Tables;
using JMComercialWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JMComercialWebApi.Controllers
{
    public class PersonaController : Controller
    {
        private readonly PersonaService _database;
        public PersonaController(IDatabase database)
        {
            _database = new PersonaService(database);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Persona persona = await _database.Get(id);
                return Ok(persona);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
