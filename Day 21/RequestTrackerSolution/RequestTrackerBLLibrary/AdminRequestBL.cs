using RequestTrackerDALLibrary;
using RequestTrackerModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class AdminRequestBL : IAdminRequestBL
    {
        protected readonly IRepository<int, Employee> _employeeRepository;
        protected readonly IRepository<int, Request> _requestRepository;
        protected readonly IRepository<int, RequestSolution> _requestSolutionRepository;

        public AdminRequestBL(IRepository<int, Employee> employeeRepository,IRepository<int, Request> requestRepository, IRepository<int, RequestSolution> requestSolutionRepository)
        {
            _employeeRepository = employeeRepository;
            _requestRepository = requestRepository;
            _requestSolutionRepository = requestSolutionRepository;
        }


        private async Task<bool> checkIsAdmin(int adminEmployeeId)
        {
            var admin = await _employeeRepository.GetByKey(adminEmployeeId);
            if (admin == null)
            {
                throw new Exception("Employee not found");
            }
            if (admin.Role == "Admin")
            {
                return true;
            }
            return false;
        }

        public async Task<RequestSolution> AddRequestSolutionByAdmin(int requestId, string solutionDescription, int adminEmployeeId)
        {
            try
            {
                bool isAdmin = await checkIsAdmin(adminEmployeeId);
                if (!isAdmin)
                {
                    throw new Exception("Employee is not an Admin");
                }
                
                var request = await _requestRepository.GetByKey(requestId);
                if (request == null)
                {
                    throw new Exception("Request not found");
                }
                RequestSolution requestSolution = new RequestSolution(solutionDescription, requestId, adminEmployeeId);
                
                var _savedRequestSolution = await _requestSolutionRepository.Add(requestSolution);
                
                if(_savedRequestSolution == null)
                {
                    throw new Exception("Unable to add request solution");
                }
                return _savedRequestSolution;
            }
            catch (Exception ex)
            {
                throw new Exception("Employee not found", ex);
            }
            
        }

        public async Task<IList<Request>> GetAllEmployeesRequestsByStatus(int adminEmployeeId, string status)
        {
            try
            {
                var isAdmin = await checkIsAdmin(adminEmployeeId);
                if (!isAdmin)
                {
                    throw new Exception("Employee is not an Admin");
                }
                
                var requests = await _requestRepository.GetAll();
                requests = requests.Where(e => e.RequestStatus == status).ToList();

                if (requests == null)
                {
                    throw new Exception("Requests not found");
                }
                return requests;
            }
            catch (Exception ex)
            {
                throw new Exception("Employee not found", ex);
            }
        }

        

        public async Task<bool> MarkedRequestCloseByAdmin(int requestId, int adminEmployeeId)
        {
            try
            {
                var isAdmin = await checkIsAdmin(adminEmployeeId);
                if (!isAdmin)
                {
                    throw new Exception("Employee is not an Admin");
                }
                var request = await _requestRepository.GetByKey(requestId);

                if (request == null)
                {
                    throw new Exception("Request not found");
                }

                var admin = await _employeeRepository.GetByKey(adminEmployeeId);
                request.ClosedDate = DateTime.Now;
                request.RequestClosedBy = admin.Id;
                request.RequestStatus = "Closed";
              
                var _savedRequest = await _requestRepository.Update(request);
                if (_savedRequest == null)
                {
                    throw new Exception("Unable to update request");
                }
                return true;
            }catch(Exception ex)
            {
                throw new Exception("Employee not found", ex);
            }
        }

        public async Task<IList<Request>> GetAllRequest()
        {
           return await _requestRepository.GetAll();
        }
    }
}
