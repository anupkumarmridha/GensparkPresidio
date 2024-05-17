using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Models.DBModels;
using EmployeeRequestTrackerAPI.Models.DTOModels;
using EmployeeRequestTrackerAPI.Repositories.Interfaces;
using EmployeeRequestTrackerAPI.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeRequestTrackerAPI.Services.Classes
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepo, IEmployeeRepository employeeRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _employeeRepo = employeeRepo;
            _tokenService = tokenService;
        }
        public async Task<LoginReturnDTO> Login(UserLoginDTO loginDTO)
        {
            var userDB = await _userRepo.GetUserByEmail(loginDTO.Email);
            if (userDB == null)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }
            HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
            if (isPasswordSame)
            {
                if (userDB.Status == "Active" || userDB.Employee.Role=="Admin")
                {
                    LoginReturnDTO loginReturnDTO = MapEmployeeToLoginReturn(userDB.Employee);
                    return loginReturnDTO;
                }

                throw new UserNotActiveException("Your account is not activated");
            }
            throw new UnauthorizedUserException("Invalid username or password");
        }

        public async Task<ReturnUserActivationDTO> UserActivation(UserActivationDTO userActivationDTO)
        {
            try
            {
                ReturnUserActivationDTO returnUserActivationDTO = null;
                if(userActivationDTO == null) {
                    throw new InvalidDataException("Invalid data");
                }
                User user = await _userRepo.GetUserByEmail(userActivationDTO.Email);
                var employee = user.Employee;
                if(user == null || employee == null){
                    throw new UnableToActivateUserException("User not found");
                }
                if (userActivationDTO.IsAdmin){
                    employee.Role = "Admin";
                    employee = await _employeeRepo.Update(employee);
                }     
                if (userActivationDTO.Activation){

                    user.Status = "Active";
                    user = await _userRepo.Update(user);              
                }
                returnUserActivationDTO = new ReturnUserActivationDTO(){
                    UserId = user.EmployeeId,
                    Status =user.Status,
                    Role = employee.Role
                };

                if (returnUserActivationDTO == null)
                {
                    throw new UnableToActivateUserException("Not able to activate user at this moment");
                }
                return returnUserActivationDTO;

            }
            catch(Exception e)
            {
                throw new UnableToActivateUserException("Not able to activate user at this moment", e.Message);
            }
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

        private Employee MapEmployeeRegisterDTOToEmployee(EmployeeRegisterDTO employeeRegisterDTO)
        {
            Employee employee = new Employee();
            employee.DateOfBirth = employeeRegisterDTO.DateOfBirth;
            employee.Name = employeeRegisterDTO.Name;
            employee.Email = employeeRegisterDTO.Email;
            employee.Phone = employeeRegisterDTO.Phone;
            employee.Image = employeeRegisterDTO.Image;
            return employee;
        }

        private bool ValidateEmployeeRegisterDTO(EmployeeRegisterDTO employeeRegisterDTO)
        {
            if (string.IsNullOrEmpty(employeeRegisterDTO.Name) || string.IsNullOrEmpty(employeeRegisterDTO.Email) || string.IsNullOrEmpty(employeeRegisterDTO.Phone) || string.IsNullOrEmpty(employeeRegisterDTO.Password) || string.IsNullOrEmpty(employeeRegisterDTO.ConfirmPassword))
            {
                return false;
            }
            return true;
        }

        public async Task<Employee> Register(EmployeeRegisterDTO employeeRegisterDTO)
        {
            if (!ValidateEmployeeRegisterDTO(employeeRegisterDTO))
            {
                throw new InvalidDataException("Invalid data");
            }

            User user = await _userRepo.GetUserByEmail(employeeRegisterDTO.Email);
            Employee employee = user?.Employee;

            if (user != null && employee!=null)
            {
                throw new UserAlreadyExistsException("User already exists");
            }
            
            if(employeeRegisterDTO.Password != employeeRegisterDTO.ConfirmPassword)
            {
                throw new PasswordMismatchException("Password and Confirm Password does not match");
            }

            try
            {
                employee = MapEmployeeRegisterDTOToEmployee(employeeRegisterDTO);
                employee = await _employeeRepo.Add(employee);
      
                user = MapEmployeeUserDTOToUser(employee.Id, employeeRegisterDTO.Password);
                user.EmployeeId = employee.Id;
                user = await _userRepo.Add(user);

                return employee;
            }
            catch (Exception) { }
            if (employee != null)
                await RevertEmployeeInsert(employee);
            if (user != null && employee == null)
                await RevertUserInsert(user);
            throw new UnableToRegisterException("Not able to register at this moment");
        }

        private LoginReturnDTO MapEmployeeToLoginReturn(Employee employee)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.EmployeeID = employee.Id;
            returnDTO.Role = employee.Role ?? "User";
            returnDTO.Token = _tokenService.GenerateToken(employee);
            return returnDTO;
        }

        private async Task RevertUserInsert(User user)
        {
            await _userRepo.DeleteByKey(user.EmployeeId);
        }

        private async Task RevertEmployeeInsert(Employee employee)
        {

            await _employeeRepo.DeleteByKey(employee.Id);
        }

        private User MapEmployeeUserDTOToUser(int id, string password)
        {
            User user = new User();
            user.EmployeeId = id;
            user.Status = "Disabled";
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(password));
            return user;
        }

        
    }
}
