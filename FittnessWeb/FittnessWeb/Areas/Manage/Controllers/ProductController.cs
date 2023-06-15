using FittnessWeb.DAL;
using FittnessWeb.Models;
using FittnessWeb.Utilities.Extensions;
using FittnessWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FittnessWeb.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        //public async Task<IActionResult> Index(int page = 1, int take = 10)
        //{
        //    var products = await _context
        //        .Products
        //        .Where(product => product.IsDeleted == false)
        //        .OrderBy(p => p.Id)
        //        .Skip((page - 1) * take)
        //        .Take(take)
        //        .Include(product => product.Category)
        //        .Include(product => product.Image)
        //        .ToListAsync();
        //    var ProductVMs = getProductList(products);
        //    var PageCount = getPageCount(take);
        //    Paginate<ProductListVM> ProductPaginate = new Paginate<ProductListVM>(ProductVMs, page, PageCount);
        //    ViewBag.PageCount = getPageCount(take);
        //    // return Json(ProductPaginate);
        //    return View(ProductPaginate);
        //}

        //private int getPageCount(int take)
        //{
        //    var productCount = _context.Products.Where(p => p.IsDeleted == false).Count();
        //    return (int)Math.Ceiling(((decimal)productCount / take));
        //}

        //private List<ProductListVM> getProductList(List<Product> products)
        //{
        //    List<ProductListVM> productLis = new List<ProductListVM>();
        //    foreach (var product in products)
        //    {
        //        var productVM = new ProductListVM
        //        {
        //            Id = product.Id,
        //            Name = product.Name,
        //            Price = product.Price,
        //            Count = product.Count,
        //            CategoryName = product.Category.Name,
        //            ProductImage = product.Image.Where(p => p.IsMain == true).FirstOrDefault().Image
        //        };
        //        productLis.Add(productVM);
        //    }

        //    return productLis;
        //}

        public async Task<IActionResult> Create()
        {
            ViewBag.categories = await _context.Categories.Where(p => p.IsDeleted == false).ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductVM product)
        {
            if (!ModelState.IsValid) return View();
            bool IsExits = _context.Products.Any(p => p.Name.ToLower().Trim() == product.Name.ToLower().Trim());
            bool CategoryIdIsExits = _context.Categories.Any(p => p.Id == product.CategoryId);
            //if (IsExits)
            //{
            //    ModelState.AddModelError("Name", "This category  already exits");
            //    return View();
            //}

            //if (!CategoryIdIsExits)
            //{
            //    ModelState.AddModelError("Name", " category not found  ");
            //}
            Product newProduct = new Product()
            {
                Name=product.Name,
                Description=product.Description,
                Price=product.Price,
                DiscPrice=product.DiscPrice,

            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            var categoryProduct = new CategoryProduct
            {
                CategoryId = product.CategoryId,
                ProductId = newProduct.Id
            };
            await _context.CategoryProducts.AddAsync(categoryProduct);
            await _context.SaveChangesAsync();
            
            foreach (var image in product.Photos)
            {
                string filename= await image.CreateFileAsync(_env.WebRootPath, "img/shop");
                _context.ProductImages.AddAsync(new ProductImage
                {
                    Path=filename,
                    ProductId=newProduct.Id
                });
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detail(int id)
        {
            return Json(new
            {
                Id = id
            });
        }

        //public async Task<IActionResult> Update(int id)
        //{
        //    var product = await _context.Products.Include(p => p.Image).Where(p => p.Id == id).FirstAsync();
        //    return View(product);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Product product)
        {
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            product.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

