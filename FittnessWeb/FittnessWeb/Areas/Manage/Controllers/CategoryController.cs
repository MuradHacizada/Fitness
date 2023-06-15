using FittnessWeb.DAL;
using FittnessWeb.Models;
using FittnessWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FittnessWeb.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        => View(await _context.Categories.ToListAsync());

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryVM category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool result = await _context.Categories.AnyAsync(c => c.Name.Trim().ToLower() == category.Name.Trim().ToLower());
            if (result)
            {
                ModelState.AddModelError("Name", "Bu adda Category ARTIQ VAR!");
                return View();
            }

            await _context.Categories.AddAsync(new Category { Name=category.Name});
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Category existed = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (existed == null) return NotFound();

            return View(existed);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Category category)
        {
            if (id == null || id < 1) return BadRequest();

            Category existed = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (existed == null) return NotFound();
            if (!ModelState.IsValid)
            {
                return View(existed);
            }
            if (existed.Name == category.Name)
            {
                RedirectToAction(nameof(Index));
            }
            bool result = await _context.Categories.AnyAsync(c => c.Name.Trim().ToLower() == category.Name.Trim().ToLower() && c.Id != existed.Id);
            if (result)
            {
                ModelState.AddModelError("Name", "Bu adda Category ARTIQ VAR!");
                return View(existed);
            }

            existed.Name = category.Name;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Category existed = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (existed == null) return NotFound();

            _context.Categories.Remove(existed);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category dbCategories = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (dbCategories == null)
            {
                return BadRequest();
            }
            return View(dbCategories);
        }
        #endregion
    }
}

