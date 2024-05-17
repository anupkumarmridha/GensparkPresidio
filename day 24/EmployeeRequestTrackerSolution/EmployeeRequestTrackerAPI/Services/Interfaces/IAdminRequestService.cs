using EmployeeRequestTrackerAPI.Models.DBModels;

namespace EmployeeRequestTrackerAPI.Services.Interfaces
{
    public interface IAdminRequestService
    {
        public Task<RequestSolution> AddRequestSolutionByAdmin(int requestId, string SolutionDescription, int adminEmployeeId);
        public Task<IList<Request>> GetAllRequest();
        public Task<IList<Request>> GetAllEmployeesRequestsByStatus(int adminEmployeeId, string status);
        public Task<bool> MarkedRequestCloseByAdmin(int requestId, int adminEmployeeId);
    }
}
