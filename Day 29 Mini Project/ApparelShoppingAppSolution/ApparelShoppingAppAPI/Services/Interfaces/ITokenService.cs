using ApparelShoppingAppAPI.Models.DB_Models;

namespace ApparelShoppingAppAPI.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(Customer customer);
    }
}
