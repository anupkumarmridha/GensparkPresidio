using System.ComponentModel.DataAnnotations;

namespace PizzaHutAPI.Models.DB_Models
{

    public class User
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public bool IsAdmin { get; set; }= false;

        // Navigation property
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
