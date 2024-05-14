using DoctorAppoinmentAPI.Models;
using DoctorAppoinmentAPI.Repositories.Interfaces;
using DoctorAppoinmentAPI.Services.Interfaces;

namespace DoctorAppoinmentAPI.Services.Classes
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetById(id);
        }

        

        public async Task<User> UpdateUser(User user)
        {
            return await _userRepository.Update(user);
        }

        public async Task<User> DeleteUser(int id)
        {
            return await _userRepository.Delete(id);
        }

        public Task<User> AddUser(string username, string email, string password, Role role)
        {
            User user = new User
            {
                Username = username,
                Email = email,
                Password = password,
                UserRole = role
            };
            return _userRepository.Add(user);
        }
    }
}
