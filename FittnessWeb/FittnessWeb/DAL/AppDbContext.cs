using FittnessWeb.DAL.ModelConfig;
using FittnessWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FittnessWeb.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Slider>Sliders { get; set; }   
        public DbSet<Benefit> Benefits { get; set; }   
        public DbSet<Package> Packages { get; set; }   
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PackageTag> PackageTags { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductCategoryConfig());


            base.OnModelCreating(builder);
        }
    }
    
}
