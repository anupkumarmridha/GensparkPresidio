using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaHutAPI.Models.DB_Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        // Navigation property
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
