using FittnessWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FittnessWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}