using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaHutAPI.Models.DB_Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        
        [Required]
        public double TotalPrice { get; set; }
        
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public string DeliveryAddress { get; set; } = string.Empty;

        // Navigation property
        public virtual Customer Customer { get; set; }

        // Navigation property
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
