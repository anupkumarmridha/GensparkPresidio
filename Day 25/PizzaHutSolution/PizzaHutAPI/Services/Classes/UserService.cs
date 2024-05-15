using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PizzaHutAPI.Models.DB_Models;
using PizzaHutAPI.Models.DTO_Models;
using PizzaHutAPI.Repositories.Interfaces;
using PizzaHutAPI.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;

namespace PizzaHutAPI.Services.Classes
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;

        public UserService(IUserRepository userRepository, ICustomerRepository customerRepository)
        {
            _userRepository = userRepository;
            _customerRepository = customerRepository;
        }

        private byte[] EncryptPassword(string password, byte[] passwordSalt)
        {
            HMACSHA512 hMACSHA = new HMACSHA512(passwordSalt);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(password));
            return encrypterPass;
        }

        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<Customer> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                var user = await _userRepository.GetUserByEmail(userLoginDTO.Email);
                if (user == null)
                {
                    throw new Exception("Invalid Email or Password");
                }
                var encryptedPassword = EncryptPassword(userLoginDTO.Password, user.PasswordHashKey);
                bool isPasswordSame = ComparePassword(encryptedPassword, user.Password);
                if (isPasswordSame)
                {
                    var customer = await _customerRepository.GetById(user.CustomerId);
                    return customer;
                }
                throw new Exception("Invalid Email or Password");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private User MapUserRegisterDTOToUser(Customer customer, string password)
        {
            User user = new User();
            user.CustomerId = customer.Id;
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(password));
            return user;
        }


        private async Task<Customer> CreateCustomer(UserRegisterDTO userRegisterDTO)
        {
            try
            {
                var customer = new Customer
                {
                    Name = userRegisterDTO.Name,
                    Email = userRegisterDTO.Email
                };
                var savedCustomer = await _customerRepository.Add(customer);
                if (savedCustomer == null)
                {
                    throw new Exception("Customer not saved");
                }
                return savedCustomer;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private async Task<Customer> AddCustomerAndUserInTransaction(UserRegisterDTO userRegisterDTO)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var customer = await CreateCustomer(userRegisterDTO);
                    var user = MapUserRegisterDTOToUser(customer, userRegisterDTO.Password);
                    var savedUser = await _userRepository.Add(user);
                    if(savedUser == null)
                    {
                        throw new Exception("User not saved");
                    }

                    scope.Complete();
                    return customer;
                }
                catch (Exception e)
                {
                    scope.Dispose();
                    throw new Exception(e.Message);
                }
            }
        }
        public async Task<Customer> Register(UserRegisterDTO userRegisterDTO)
        {
            try
            {
                var existingCustomer = await _customerRepository.GetCustomerByEmail(userRegisterDTO.Email);
                if (existingCustomer != null)
                {
                    throw new Exception("Email already exists");
                }
                if (userRegisterDTO.Password != userRegisterDTO.ConfirmPassword)
                {
                    throw new Exception("Password and Confirm Password do not match");
                }
                var customer = await AddCustomerAndUserInTransaction(userRegisterDTO);
                if(customer == null)
                {
                    throw new Exception("Customer not saved");
                }
                return customer;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
