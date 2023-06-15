namespace FittnessWeb.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal DiscPrice { get; set; }
        public ICollection<ProductImage>ProductImages { get; set; }
        public ICollection<CategoryProduct> CategoryProducts { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }
    }
}
