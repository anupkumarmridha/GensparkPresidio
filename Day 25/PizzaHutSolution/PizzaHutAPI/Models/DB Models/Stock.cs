using System.ComponentModel.DataAnnotations;

namespace PizzaHutAPI.Models.DB_Models
{
    public class Stock
    {
        public int Id { get; set; }
        
        [Required]
        public int PizzaID { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public DateTime LastUpdatedDate { get; set; }

        // Navigation property
        public virtual Pizza? Pizza { get; set; }
    }
}
