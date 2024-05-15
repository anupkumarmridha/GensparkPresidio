using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaHutAPI.Models.DB_Models
{
    public enum CartStatus
    {
        Active,
        Expired,
        Completed,
    }

    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }= DateTime.Now;

        [Required]
        public DateTime LastUpdatedDate { get; set; }

        [Required]
        public CartStatus Status { get; set; } = CartStatus.Active;

        // Navigation property
        public virtual Customer Customer { get; set; }

        // Collection navigation property for items added to the cart
        public virtual ICollection<CartItem> Items { get; set; }
    }
}
