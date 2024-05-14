using DoctorAppoinmentAPI.Models;

namespace DoctorAppoinmentAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> AddUser(string username, string email, string password, Role role);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int id);
    }
}
