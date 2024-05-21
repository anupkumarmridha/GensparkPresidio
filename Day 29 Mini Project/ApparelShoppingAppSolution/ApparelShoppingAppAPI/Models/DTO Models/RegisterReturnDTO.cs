using ApparelShoppingAppAPI.Models.DB_Models;

namespace ApparelShoppingAppAPI.Models.DTO_Models
{
    public class RegisterReturnDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
    }
}
