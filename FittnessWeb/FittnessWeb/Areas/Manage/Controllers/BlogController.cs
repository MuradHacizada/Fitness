using FittnessWeb.DAL;
using FittnessWeb.Models;
using FittnessWeb.Utilities.Extensions;
using FittnessWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FittnessWeb.Areas.Manage.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public BlogController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index(int page = 0)
        {
            List<Blog> blogs = await _db.Blogs.Skip(page * 5).Take(5).ToListAsync();
            PaginateVM<Blog> paginate = new PaginateVM<Blog>
            {
                Items = blogs,
                TotalPage = Math.Ceiling((decimal)_db.Blogs.Count() / 5),
                CurrentPage = page
            };
            return View(paginate);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Position = await _db.Positions.ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog)
        {
            ViewBag.Position = await _db.Positions.ToListAsync();
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View();
            }

            if (blog.Photo == null) { ModelState.AddModelError("Photo", "Zehmet olmasa sekil secin"); return View(); }
            if (!blog.Photo.CheckFileType("image/")) { ModelState.AddModelError("Photo", "Sekil tipi uygun deyil"); return View(); }
            if (!blog.Photo.CheckFileSize(400)) { ModelState.AddModelError("Photo", "Sekil uzunlugu uygun deyil"); return View(); }
            blog.Image = await blog.Photo.CreateFileAsync(_env.WebRootPath, "img/blog-post");
            await _db.Blogs.AddAsync(blog);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Position = await _db.Positions.ToListAsync();
            if (id < 1 || id == null) { return BadRequest(); }
            Blog existed = await _db.Blogs.FirstOrDefaultAsync(p => p.Id == id);
            if (existed == null) { return NotFound(); }
            return View(existed);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Update(int? id, Blog blog)
        {
            ViewBag.Position = await _db.Positions.ToListAsync();
            if (id < 1 || id == null) { return BadRequest(); }
            Blog existed = await _db.Blogs.FirstOrDefaultAsync(p => p.Id == id);
            if (existed == null) { return NotFound(); }
            if (blog.Photo != null)
            {
                if (!blog.Photo.CheckFileType("image/")) { ModelState.AddModelError("Photo", "Sekil tipi uygun deyil"); return View(); }
                if (!blog.Photo.CheckFileSize(400)) { ModelState.AddModelError("Photo", "Sekil uzunlugu uygun deyil"); return View(); }
                existed.Image.DeleteFile(_env.WebRootPath, "img/blog-post");
                existed.Image = await blog.Photo.CreateFileAsync(_env.WebRootPath, "img/blog-post");
            }
            existed.Title = blog.Title;
            existed.Description = blog.Description;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id < 1 || id == null) { return BadRequest(); }
            Blog existed = await _db.Blogs.FirstOrDefaultAsync(p => p.Id == id);
            if (existed == null) { return NotFound(); }
            existed.Image.DeleteFile(_env.WebRootPath, "assets/img/team");
            _db.Blogs.Remove(existed);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
