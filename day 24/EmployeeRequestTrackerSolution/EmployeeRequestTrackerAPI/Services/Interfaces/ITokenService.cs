using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(Employee employee);
    }
}
