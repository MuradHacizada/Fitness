using Microsoft.AspNetCore.Identity;

namespace FittnessWeb.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public BasketItem Basket { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}