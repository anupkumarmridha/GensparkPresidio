using System.ComponentModel.DataAnnotations;

namespace ApparelShoppingAppAPI.Models.DTO_Models
{
    public class ProductDTO
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
