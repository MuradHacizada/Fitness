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
    }
}
