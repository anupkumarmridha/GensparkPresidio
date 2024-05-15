using System.ComponentModel.DataAnnotations;

namespace PizzaHutAPI.Models.DB_Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        
        [Required]
        public double TotalPrice { get; set; }
        
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public string DeliveryAddress { get; set; } = string.Empty;

        // Navigation property
        public virtual User? User { get; set; }

        // Navigation property
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
