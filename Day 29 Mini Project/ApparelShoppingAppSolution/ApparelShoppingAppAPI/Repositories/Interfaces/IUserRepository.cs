using ApparelShoppingAppAPI.Models.DB_Models;

namespace ApparelShoppingAppAPI.Repositories.Interfaces
{
    public interface IUserRepository:IRepository<int, User>
    {
        Task<User> GetUserByEmail(string email);
    }
}
