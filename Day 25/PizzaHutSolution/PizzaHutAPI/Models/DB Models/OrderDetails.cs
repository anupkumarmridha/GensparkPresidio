using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaHutAPI.Models.DB_Models
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int PizzaId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double SubtotalPrice { get; set; }

        // Navigation property
        public virtual Order Order { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
