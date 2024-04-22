using MovieBookingBLLibery.Interfaces;
using MovieBookingDALLibery.Interfaces;
using MovieBookingModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingBLLibery.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Add(User entity)
        {
            // Check if the username already exists
            if (_userRepository.GetAll().Exists(u => u.Username == entity.Username))
            {
                throw new InvalidOperationException($"User with username '{entity.Username}' already exists.");
            }
            return _userRepository.Add(entity);
        }

        public bool Delete(int id)
        {
            User userToDelete = GetById(id);
            if (userToDelete == null)
            {
                return false;
            }
            return _userRepository.Delete(id);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User GetUserByUsername(string username)
        {
            try
            {
                return _userRepository.GetUserByUsername(username);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public User Update(User entity)
        {
            if (GetById(entity.Id) == null)
            {
                throw new KeyNotFoundException($"User with ID {entity.Id} not found.");
            }
            return _userRepository.Update(entity);
        }
    }
}
