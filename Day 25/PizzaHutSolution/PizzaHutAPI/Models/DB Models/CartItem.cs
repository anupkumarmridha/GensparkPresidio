using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaHutAPI.Models.DB_Models
{
    public class CartItem
    {
        public int Id { get; set; }

        [Required]
        public int CartID { get; set; }

        [Required]
        public int PizzaID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        // Navigation properties
        public virtual Cart? Cart { get; set; }
        public virtual Pizza? Pizza { get; set; }
    }
}
