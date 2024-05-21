using ApparelShoppingAppAPI.Models.DB_Models;
using ApparelShoppingAppAPI.Models.DTO_Models;

namespace ApparelShoppingAppAPI.Repositories.Interfaces
{
    public interface IUserRegisterRepository
    {
        Task<(Customer customer, User user)> AddUserWithTransaction(UserRegisterRepositoryDTO userRegisterDTO);
    }
}
