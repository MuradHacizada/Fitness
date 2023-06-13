using FittnessWeb.DAL;
using FittnessWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FittnessWeb.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        public BlogController(AppDbContext db)
        {
                _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _db.Blogs.ToListAsync();
            return View(blogs);
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
