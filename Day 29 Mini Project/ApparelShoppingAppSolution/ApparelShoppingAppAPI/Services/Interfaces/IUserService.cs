using ApparelShoppingAppAPI.Models.DTO_Models;

namespace ApparelShoppingAppAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<RegisterReturnDTO> Register(UserRegisterDTO userRegisterDTO);
        Task<LoginReturnDTO> Login(UserLoginDTO userLoginDTO);
    }
}
