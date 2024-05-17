using EmployeeRequestTrackerAPI.Models.DBModels;
using EmployeeRequestTrackerAPI.Models.DTOModels;

namespace EmployeeRequestTrackerAPI.Services.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<Employee> Register(EmployeeRegisterDTO employeeRegisterDTO);
        public Task<ReturnUserActivationDTO> UserActivation(UserActivationDTO userActivationDTO);
    }
}
