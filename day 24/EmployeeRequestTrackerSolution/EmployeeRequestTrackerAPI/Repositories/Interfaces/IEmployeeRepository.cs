using EmployeeRequestTrackerAPI.Models.DBModels;

namespace EmployeeRequestTrackerAPI.Repositories.Interfaces
{
    public interface IEmployeeRepository:IRepository<int, Employee>
    {
        Task<Employee> GetEmployeeByEmail(string email);
    }
}
