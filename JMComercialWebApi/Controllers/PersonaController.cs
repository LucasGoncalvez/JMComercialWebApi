using JMComercialWebApi.Data;
using JMComercialWebApi.Models.Tables;
using JMComercialWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JMComercialWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : Controller
    {
        private readonly PersonaService _database;
        public PersonaController(IDatabase database)
        {
            _database = new PersonaService(database);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> Get(int id)
        {
            try
            {
                var persona = await _database.Get(id);
                if (persona == null)
                {
                    return NotFound(); // Retorna un código de estado 404 si no se encuentra la persona
                }
                return Ok(persona); // Retorna un código de estado 200 con la persona encontrada
            }
            catch (Exception ex)
            {
                return BadRequest($"Ha ocurrido un error: {ex.Message}"); // Retorna un código de estado 400 en caso de error
            }
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var personas = await _database.GetAll();
                if (personas == null)
                {
                    return NotFound(); // Retorna un código de estado 404 si no se encuentra
                }
                return Ok(personas); // Retorna un código de estado 200 con lo encontrado
            }
            catch (Exception ex)
            {
                return BadRequest($"Ha ocurrido un error: {ex.Message}"); // Retorna un código de estado 400 en caso de error
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add(Persona persona)
        {
            try
            {
                await _database.Add(persona);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ha ocurrido un error: {ex.Message}");
            }
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update(Persona persona)
        {
            try
            {
                await _database.Update(persona);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _database.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
