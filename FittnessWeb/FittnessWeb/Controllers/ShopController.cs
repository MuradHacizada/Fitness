using Microsoft.AspNetCore.Mvc;

namespace FittnessWeb.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
