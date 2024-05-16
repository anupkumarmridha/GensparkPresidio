using PizzaHutAPI.Models.DB_Models;

namespace PizzaHutAPI.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(Customer customer);
    }
}
