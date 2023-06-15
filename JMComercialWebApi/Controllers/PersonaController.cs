using Microsoft.AspNetCore.Mvc;

namespace JMComercialWebApi.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
