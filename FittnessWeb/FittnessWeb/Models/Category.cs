using System.ComponentModel.DataAnnotations.Schema;

namespace FittnessWeb.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<CategoryProduct> CategoryProducts { get; set; }
        
    }
    public class CategoryProduct
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
    public class ProductImage
    {
        public int Id { get; set; }
        public string Path { get; set; }
        [NotMapped]
        public IFormFile Photo { get;set; }
        public int ProductId { get; set; }
    }
    public class Comment
    {
        public int Id { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }
    }
    public class ProductComment
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CommentId { get; set; }

        public Comment Comment { get; set; }
        public Product Product { get; set; }
    }
}
