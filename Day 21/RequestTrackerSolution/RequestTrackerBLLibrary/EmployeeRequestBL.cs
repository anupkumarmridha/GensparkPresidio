using RequestTrackerModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class EmployeeRequestBL : IEmployeeRequestBL
    {
        EmployeeRequestBL()
        {

        }

        public Task<Request> AddRequest(int employeeId, string RequestMessage)
        {
            throw new NotImplementedException();
        }

        public Task<List<Request>> GetAllRequestByEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<RequestSolution>> GetAllRequestSolutionByEmployee(int requestId)
        {
            throw new NotImplementedException();
        }

        public Task<Request> GetRequestByEmployee(int requestId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRequestStatus(int requestId)
        {
            throw new NotImplementedException();
        }

        public Task<RequestSolution> ResponseToSolution(int solutionId, string response)
        {
            throw new NotImplementedException();
        }
    }
}
