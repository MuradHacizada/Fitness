using Microsoft.AspNetCore.Mvc;

namespace FittnessWeb.Controllers
{
    public class GaleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
