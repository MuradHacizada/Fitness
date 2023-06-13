using Microsoft.AspNetCore.Mvc;

namespace FittnessWeb.Areas.Manage.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
