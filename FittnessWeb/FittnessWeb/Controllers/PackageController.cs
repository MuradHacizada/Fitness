using FittnessWeb.DAL;
using FittnessWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FittnessWeb.Controllers
{
    public class PackageController : Controller
    {
        private readonly AppDbContext _db;
        public PackageController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            Package package = _db.Packages.Include(p => p.PackageTags).ThenInclude(pt => pt.Tag).FirstOrDefault();
            return View(package);
        }
        public IActionResult Pricing()
        {
            return View();
        }
    }
}
