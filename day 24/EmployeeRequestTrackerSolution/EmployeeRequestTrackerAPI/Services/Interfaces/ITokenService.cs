using EmployeeRequestTrackerAPI.Models.DBModels;

namespace EmployeeRequestTrackerAPI.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(Employee employee);
    }
}
