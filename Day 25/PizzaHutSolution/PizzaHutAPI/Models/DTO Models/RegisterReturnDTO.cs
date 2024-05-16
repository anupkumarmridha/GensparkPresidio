using PizzaHutAPI.Models.DB_Models;

namespace PizzaHutAPI.Models.DTO_Models
{
    public class RegisterReturnDTO
    {
        public Customer Customer { get; set; }
        public string Token { get; set; }
        public bool Role { get; set; }
    }
}
