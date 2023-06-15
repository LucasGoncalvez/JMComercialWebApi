using JMComercialWebApi.Data;
using JMComercialWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JMComercialWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PruebaController : Controller
    {
        private PruebaService _data;
        public PruebaController(IDatabase data)
        {
            _data = new PruebaService(data);
        }

        [HttpGet("Get")]
        public IActionResult Get()
        {
            string message = _data.Get();
            return Ok(message);
        }
    }
}
