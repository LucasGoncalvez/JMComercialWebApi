using JMComercialWebApi.Data;
using JMComercialWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JMComercialWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UbicacionController : Controller
    {
        private readonly UbicacionService _database;
        public UbicacionController(IDatabase database)
        {
            _database = new UbicacionService(database);
        }

        [HttpGet]
        [Route("GetCiudades")]
        public async Task<IActionResult> GetCiudades()
        {
            try
            {
                var ciudades = await _database.GetCiudades();
                if(ciudades == null)
                {
                    return NotFound();
                }
                return Ok(ciudades);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
