﻿using ApparelShoppingAppAPI.Models.DB_Models;
using ApparelShoppingAppAPI.Models.DTO_Models;
using ApparelShoppingAppAPI.Repositories.Interfaces;
using ApparelShoppingAppAPI.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;
using ApparelShoppingAppAPI.Exceptions;

namespace ApparelShoppingAppAPI.Services.Classes
{
    public class UserService : IUserService
    {
        private readonly IUserRegisterRepository _userRegisterRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, 
            ICustomerRepository customerRepository,
            IUserRegisterRepository userRegisterRepository,
            ITokenService tokenService
            )
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _userRegisterRepository = userRegisterRepository;
            _tokenService = tokenService;
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
        private LoginReturnDTO MapCustomerToLoginReturn(User user)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.CustomerId =user.CustomerId;
            returnDTO.Role = user.Role;
            returnDTO.Token = _tokenService.GenerateToken(user.Customer);
            return returnDTO;
        }
        public async Task<LoginReturnDTO> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                var user = await _userRepository.GetUserByEmail(userLoginDTO.Email);
                if (user == null)
                {
                    throw new UnauthorizedUserException("Invalid Email or Password");
                }
                var encryptedPassword = EncryptPassword(userLoginDTO.Password, user.PasswordHashKey);
                bool isPasswordSame = ComparePassword(encryptedPassword, user.Password);
                if (isPasswordSame)
                {
                    if (user.Customer == null)
                    {
                        throw new UnauthorizedUserException("Invalid Email or Password");
                    }
                    LoginReturnDTO loginReturnDTO = MapCustomerToLoginReturn(user);
                    if(loginReturnDTO == null)
                    {
                        throw new NotAbelToLoginException("Error while generating token");
                    }
                    return loginReturnDTO;
                }
                throw new UnauthorizedUserException("Invalid Email or Password");
            }
            catch (Exception e)
            {
                throw new NotAbelToLoginException(e.Message);
            }
        }

        private RegisterReturnDTO MapCustomerToRegisterReturn(User user, Customer customer)
        {
            RegisterReturnDTO returnDTO = new RegisterReturnDTO();
            returnDTO.Name = customer.Name;
            returnDTO.Email = customer.Email;
            returnDTO.Role = user.Role;
            returnDTO.Token = _tokenService.GenerateToken(user.Customer);
            return returnDTO;
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
       

        public async Task<RegisterReturnDTO> Register(UserRegisterDTO userRegisterDTO)
        {
            try
            {
                var existingCustomer = await _customerRepository.GetCustomerByEmail(userRegisterDTO.Email);
                if (existingCustomer != null)
                {
                    throw new UserAlreadyExistsException("Email already exists");
                }
                if (userRegisterDTO.Password != userRegisterDTO.ConfirmPassword)
                {
                    throw new PasswordMismatchException("Password and Confirm Password do not match");
                }
                UserRegisterRepositoryDTO userRegisterRepositoryDTO = MapUserRegisterRepositoryDTO(userRegisterDTO);
                var (customer, user) = await _userRegisterRepository.AddUserWithTransaction(userRegisterRepositoryDTO);
                
                if (customer == null || user == null)
                {
                    throw new UnableToRegisterException("Error while adding user");
                }
                RegisterReturnDTO registerReturnDTO = MapCustomerToRegisterReturn(user, customer);
                return registerReturnDTO;
            }
            catch (Exception e)
            {
                throw new UnableToRegisterException(e.Message);
            }
        }
    }
   

}
