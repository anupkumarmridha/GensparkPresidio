using EmployeeRequestTrackerAPI.Models.DBModels;
using EmployeeRequestTrackerAPI.Repositories.Interfaces;
using EmployeeRequestTrackerAPI.Services.Interfaces;

namespace EmployeeRequestTrackerAPI.Services.Classes
{
    public class EmployeeRequestService:IEmployeeRequestService
    {
        protected IRepository<int, Employee> _employeeRepository;
        protected readonly IRepository<int, Request> _requestRepository;
        protected readonly IRepository<int, RequestSolution> _requestSolutionRepository;
        protected readonly IRepository<int, SolutionFeedback> _solutionFeedbackRepository;

        public EmployeeRequestService(IRepository<int, Employee> employeeRepository,
            IRepository<int, Request> requestRepository,
            IRepository<int, RequestSolution> requestSolutionRepository,
            IRepository<int, SolutionFeedback> solutionFeedbackRepository)
        {
            _employeeRepository = employeeRepository;
            _requestRepository = requestRepository;
            _requestSolutionRepository = requestSolutionRepository;
            _solutionFeedbackRepository = solutionFeedbackRepository;
        }

        public async Task<Request> AddRequest(int employeeId, string RequestMessage)
        {

            Employee employee = await _employeeRepository.GetByKey(employeeId);
            await Console.Out.WriteLineAsync(employee.Name);

            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            Request request = new Request(RequestMessage, employee.Id);

            try
            {
                return await _requestRepository.Add(request);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to add request", ex);
            }
        }

        public async Task<List<Request>> GetAllRequestByEmployee(int employeeId)
        {
            try
            {
                var requests = await _requestRepository.GetAll();
                return requests.Where(e => e.RequestRaisedBy == employeeId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get all request", ex);
            }
        }

        public async Task<IList<RequestSolution>> GetAllSolutionByRequestOfEmployee(int requestId)
        {
            try
            {
                var request = await _requestRepository.GetByKey(requestId);
                if (request == null)
                {
                    throw new Exception("Request not found");
                }
                return request.RequestSolutions.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get all request solution", ex);
            }
        }


        public async Task<string> GetRequestStatus(int requestId)
        {
            var request = await _requestRepository.GetByKey(requestId);
            if (request == null)
            {
                throw new Exception("Request not found");
            }
            return await Task.FromResult(request.RequestStatus);
        }

        public async Task<RequestSolution> ResponseToSolution(int solutionId, string response)
        {
            var solution = await _requestSolutionRepository.GetByKey(solutionId);
            if (solution == null)
            {
                throw new Exception("Request Solution not found");
            }
            solution.RequestRaiserComment = response;
            return await _requestSolutionRepository.Update(solution);
        }

        public async Task<IList<Request>> GetAllRequestByStatus(int employeeId, string status)
        {
            var requests = await _requestRepository.GetAll();
            return requests.Where(e => e.RequestRaisedBy == employeeId && e.RequestStatus == status).ToList();
        }

        public async Task<RequestSolution> AcceptSolution(int solutionId)
        {
            var requestSolution = await _requestSolutionRepository.GetByKey(solutionId);

            if (requestSolution == null)
            {
                throw new Exception("Request Solution not found");
            }
            if (requestSolution.IsSolved)
            {
                throw new Exception("Request Solution already accepted");
            }
            requestSolution.IsSolved = true;
            return await _requestSolutionRepository.Update(requestSolution);
        }
    }
}
