using System.ComponentModel.DataAnnotations.Schema;

namespace FittnessWeb.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? Photo { get; set; }
        public List<PackageTag> PackageTags { get; set; }
    }
}
