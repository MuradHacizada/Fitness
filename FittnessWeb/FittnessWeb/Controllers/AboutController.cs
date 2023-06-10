using Microsoft.AspNetCore.Mvc;

namespace FittnessWeb.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
