﻿using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PizzaHutAPI.Models.DB_Models;
using PizzaHutAPI.Models.DTO_Models;
using PizzaHutAPI.Repositories.Classes;
using PizzaHutAPI.Repositories.Interfaces;
using PizzaHutAPI.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;

namespace PizzaHutAPI.Services.Classes
{
    public class UserService : IUserService
    {
        private readonly IUserRegisterRepository _userRegisterRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;

        public UserService(IUserRepository userRepository, 
            ICustomerRepository customerRepository,
            IUserRegisterRepository userRegisterRepository
            )
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _userRegisterRepository = userRegisterRepository;
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

        private UserRegisterRepositoryDTO MapUserRegisterRepositoryDTO(UserRegisterDTO userRegisterDTO)
        {
            UserRegisterRepositoryDTO userRegisterRepositoryDTO = new UserRegisterRepositoryDTO();
            HMACSHA512 hMACSHA = new HMACSHA512();
            userRegisterRepositoryDTO.PasswordHashKey = hMACSHA.Key;
            userRegisterRepositoryDTO.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDTO.Password));
            userRegisterRepositoryDTO.Name = userRegisterDTO.Name;
            userRegisterRepositoryDTO.Email = userRegisterDTO.Email;
            return userRegisterRepositoryDTO;
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
                UserRegisterRepositoryDTO userRegisterRepositoryDTO = MapUserRegisterRepositoryDTO(userRegisterDTO);
                var (customer, user) = await _userRegisterRepository.AddUserWithTransaction(userRegisterRepositoryDTO);
                
                if (customer == null || user == null)
                {
                    throw new Exception("Error while adding user");
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