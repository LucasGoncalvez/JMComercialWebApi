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

        #region Get
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
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
        #endregion

        #region GetAll
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var personas = await _database.GetAll();
                if (personas == null || personas.Count == 0)
                {
                    return NotFound(); // Retorna un código de estado 404 si no existen registros
                }
                return Ok(personas); // Retorna un código de estado 200 con los regitros encontrados
            }
            catch (Exception ex)
            {
                return BadRequest($"Ha ocurrido un error: {ex.Message}"); // Retorna un código de estado 400 en caso de error
            }
        }
        #endregion

        #region Add
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
        #endregion

        #region Update
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Persona persona)
        {
            try
            {
                int? result = await _database.Update(persona); //Retorna la cantidad de registros afectados
                if (result == null)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Delete
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
        #endregion


        #region GetContactos
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
        #endregion

        #region AddContacts
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
        #endregion

        #region UpdateContactos
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
        #endregion

        #region DeleteContacto
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
        #endregion
    }
}
