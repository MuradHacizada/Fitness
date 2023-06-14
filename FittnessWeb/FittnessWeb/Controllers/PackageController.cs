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
        public async Task<IActionResult> Index()
        {
            List<Package> packages = await _db.Packages.Include(p => p.PackageTags).ThenInclude(pt => pt.Tag).ToListAsync();
            return View(packages);
        }
        public IActionResult Pricing()
        {
            return View();
        }
    }
}
