using Microsoft.AspNetCore.Mvc;

namespace FittnessWeb.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
