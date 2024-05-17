using EmployeeRequestTrackerAPI.Models.DBModels;

namespace EmployeeRequestTrackerAPI.Repositories.Interfaces
{
    public interface IUserRepository:IRepository<int, User>
    {
        Task<User> GetUserByEmail(string email);
    }
}
