using Microsoft.AspNetCore.Mvc;

namespace FittnessWeb.Controllers
{
    public class PackageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Pricing()
        {
            return View();
        }
    }
}
