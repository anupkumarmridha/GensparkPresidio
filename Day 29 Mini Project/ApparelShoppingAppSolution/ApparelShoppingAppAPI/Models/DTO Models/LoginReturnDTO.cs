using ApparelShoppingAppAPI.Models.DB_Models;

namespace ApparelShoppingAppAPI.Models.DTO_Models
{
    public class LoginReturnDTO
    {
        public int CustomerId { get; set; }
        public string Token { get; set; }
        public Role Role { get; set; }
    }
}
