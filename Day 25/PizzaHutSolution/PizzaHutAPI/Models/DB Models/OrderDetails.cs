using System.ComponentModel.DataAnnotations;

namespace PizzaHutAPI.Models.DB_Models
{
    public class OrderDetails
    {
        public int Id { get; set; }

        [Required]
        public int OrderID { get; set; }

        [Required]
        public int PizzaID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double SubtotalPrice { get; set; }

        // Navigation property
        public virtual Order? Order { get; set; }
        public virtual Pizza? Pizza { get; set; }
    }
}
