using PizzaHutAPI.Models.DB_Models;
using PizzaHutAPI.Models.DTO_Models;

namespace PizzaHutAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<Customer> Register(UserRegisterDTO userRegisterDTO);
        Task<LoginReturnDTO> Login(UserLoginDTO userLoginDTO);
    }
}
