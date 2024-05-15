using System.ComponentModel.DataAnnotations;

namespace PizzaHutAPI.Models.DTO_Models
{
    public class UserLoginDTO
    {
        [Required]
        public string Email { get; set; }
        
        [Required]        
        public string Password { get; set; }
    }
}
