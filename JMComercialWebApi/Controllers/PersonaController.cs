using JMComercialWebApi.Data;
using JMComercialWebApi.Models.Details;
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

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<PersonaDetail?>> Get(int id)
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

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var personas = await _database.GetAll();
                if (personas == null || personas.Count == 0)
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

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add(Persona persona)
        {
            try
            {
                int? result = await _database.Add(persona);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ha ocurrido un error: {ex.Message}");
            }
        }


        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Persona persona)
        {
            try
            {
                int? result = await _database.Update(persona); //Retorna la cantidad de registros afectados
                if (result == null)
                {
                    return BadRequest("No se pudo actualizar a Persona");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
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

        [HttpPost]
        [Route("AddContacts")]
        public async Task<IActionResult> AddContacts(List<PersonaContacto>? listaContactos)
        {
            try
            {
                var result = await _database.AddContactos(listaContactos);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetContacts")]
        public async Task<IActionResult> GetContacts(int personaId)
        {
            try
            {
                var result = await _database.GetContactos(personaId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateContactos")]
        public async Task<IActionResult> UpdateContactos(List<PersonaContacto> contactos)
        {
            try
            {
                var result = await _database.UpdateContactos(contactos);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteContacto")]
        public async Task<IActionResult> DeleteContacto(int contactoId)
        {
            try
            {
                await _database.DeleteContacto(contactoId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
