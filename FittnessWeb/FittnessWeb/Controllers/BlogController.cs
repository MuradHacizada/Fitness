using Microsoft.AspNetCore.Mvc;

namespace FittnessWeb.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
