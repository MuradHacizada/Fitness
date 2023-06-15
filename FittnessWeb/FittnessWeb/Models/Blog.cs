using System.ComponentModel.DataAnnotations.Schema;

namespace FittnessWeb.Models
{
    public class Blog
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public string MainDesc { get; set; }
        public string Icon { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? Photo { get; set; }
    }
    public class BlogComment
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int CommentId { get; set; }

        public Comment Comment { get; set; }
        public Blog Blog { get; set; }
    }
}
