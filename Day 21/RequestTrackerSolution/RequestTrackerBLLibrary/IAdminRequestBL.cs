using RequestTrackerModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IAdminRequestBL
    {
        public Task<RequestSolution> AddRequestSolutionByAdmin(int requestId, string SolutionDescription, int adminEmployeeId);
        public Task<IList<Request>> GetAllRequest();
        public Task<IList<Request>> GetAllEmployeesRequestsByStatus(int adminEmployeeId, string status);
        public Task<bool> MarkedRequestCloseByAdmin(int requestId, int adminEmployeeId);
    }
}
