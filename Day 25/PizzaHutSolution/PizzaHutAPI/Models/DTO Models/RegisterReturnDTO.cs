using PizzaHutAPI.Models.DB_Models;

namespace PizzaHutAPI.Models.DTO_Models
{
    public class RegisterReturnDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
    }
}
