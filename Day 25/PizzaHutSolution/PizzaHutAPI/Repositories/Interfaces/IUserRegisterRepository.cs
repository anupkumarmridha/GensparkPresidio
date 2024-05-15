using PizzaHutAPI.Models.DB_Models;
using PizzaHutAPI.Models.DTO_Models;

namespace PizzaHutAPI.Repositories.Interfaces
{
    public interface IUserRegisterRepository
    {
        Task<(Customer customer, User user)> AddUserWithTransaction(UserRegisterRepositoryDTO userRegisterDTO);
    }
}
