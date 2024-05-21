using System.ComponentModel.DataAnnotations;

namespace ApparelShoppingAppAPI.Models.DTO_Models
{
    public class UserRegisterRepositoryDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public byte[] Password { get; set; }

        [Required]
        public byte[] PasswordHashKey { get; set; }
    }
}
