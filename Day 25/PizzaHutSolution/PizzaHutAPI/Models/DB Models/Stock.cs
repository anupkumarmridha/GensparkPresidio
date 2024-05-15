using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaHutAPI.Models.DB_Models
{
    public class Stock
    {
        [Key]
        public int PizzaId { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public DateTime LastUpdatedDate { get; set; }

        // Navigation property
        public virtual Pizza Pizza { get; set; }
    }
}
