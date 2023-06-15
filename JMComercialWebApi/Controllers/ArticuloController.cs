using Microsoft.AspNetCore.Mvc;

namespace JMComercialWebApi.Controllers
{
    public class ArticuloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
