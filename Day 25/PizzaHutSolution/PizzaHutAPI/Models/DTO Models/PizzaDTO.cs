using System.ComponentModel.DataAnnotations;

namespace PizzaHutAPI.Models.DTO_Models
{
    public class PizzaDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }
        public string? ImageUrl { get; set; }
    }
}
