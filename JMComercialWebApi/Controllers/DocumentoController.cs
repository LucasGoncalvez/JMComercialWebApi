using JMComercialWebApi.Data;
using JMComercialWebApi.Models.Tables;
using JMComercialWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JMComercialWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentoController : Controller
    {
        private readonly DocumentoService _database;
        public DocumentoController(IDatabase database)
        {
            _database = new DocumentoService(database);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listTipoDocumento = await _database.GetAll();
                if (listTipoDocumento == null)
                {
                    return NotFound();
                }
                return Ok(listTipoDocumento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
