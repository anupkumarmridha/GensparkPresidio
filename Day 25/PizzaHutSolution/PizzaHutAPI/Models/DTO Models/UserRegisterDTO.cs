using System.ComponentModel.DataAnnotations;

namespace PizzaHutAPI.Models.DTO_Models
{
    public class UserRegisterDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
