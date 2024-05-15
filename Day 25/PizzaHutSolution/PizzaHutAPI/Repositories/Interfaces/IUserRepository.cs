using PizzaHutAPI.Models.DB_Models;

namespace PizzaHutAPI.Repositories.Interfaces
{
    public interface IUserRepository:IRepository<int, User>
    {
        Task<User> GetUserByEmail(string email);
    }
}
