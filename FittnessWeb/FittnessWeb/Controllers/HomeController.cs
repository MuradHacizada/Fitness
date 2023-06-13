using FittnessWeb.DAL;
using FittnessWeb.Models;
using FittnessWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FittnessWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Sliders = await _db.Sliders.ToListAsync(),
                Benefits=await _db.Benefits.ToListAsync()
            };
            return View(homeVM);
        }
    }
}