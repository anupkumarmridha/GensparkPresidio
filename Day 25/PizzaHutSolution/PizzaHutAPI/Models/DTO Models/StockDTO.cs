using System.ComponentModel.DataAnnotations;

namespace PizzaHutAPI.Models.DTO_Models
{
    public class StockDTO
    {
        [Required]
        public int PizzaId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
