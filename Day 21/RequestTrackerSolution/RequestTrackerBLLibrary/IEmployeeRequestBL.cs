using RequestTrackerModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IEmployeeRequestBL
    {
        public Task<Request> AddRequest(int employeeId, string RequestMessage);
        public Task<string> GetRequestStatus(int requestId);
        public Task<Request> GetRequestByEmployee(int requestId);
        public Task<List<Request>> GetAllRequestByEmployee(int employeeId);
        public Task<RequestSolution> ResponseToSolution(int solutionId, string response);
        public Task<List<RequestSolution>> GetAllRequestSolutionByEmployee(int requestId);
    }
}
