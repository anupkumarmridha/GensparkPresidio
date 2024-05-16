using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaHutAPI.Models.DB_Models
{
    public class Stock
    {
        [Key]
        [ForeignKey("Pizza")]
        public int PizzaId { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public DateTime LastUpdatedDate { get; set; }
    }
}
