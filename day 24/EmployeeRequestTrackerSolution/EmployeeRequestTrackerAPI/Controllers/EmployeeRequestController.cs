using EmployeeRequestTrackerAPI.Models.DBModels;
using EmployeeRequestTrackerAPI.Models.DTOModels;
using EmployeeRequestTrackerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRequestController : ControllerBase
    {
        private readonly IEmployeeRequestService _employeeRequestService;


        public EmployeeRequestController(IEmployeeRequestService employeeRequestService, IEmployeeService employeeService, ITokenService tokenService)
        {
            _employeeRequestService = employeeRequestService;
        }

        [Authorize]
        [HttpPost("AddRequest")]
        [ProducesResponseType(typeof(Request), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddRequest(RequestDTO request)
        {
            try
            {
                var employeeId = User.FindFirstValue(ClaimTypes.Name);
                if (employeeId == null)
                {
                    return BadRequest("Invalid User");
                }
                var RequestRaisedBy = Convert.ToInt32(employeeId);
                var _request = await _employeeRequestService.AddRequest(RequestRaisedBy, request.RequestMessage);
                return Ok(_request);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(500, ex.Message));
            }
        }

        [Authorize]
        [HttpGet("GetRequestStatus")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetRequestStatus(int requestId)
        {
            try
            {
                var status = await _employeeRequestService.GetRequestStatus(requestId);
                return Ok(status);
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [Authorize]
        [HttpGet("GetAllRequestByEmployee")]
        [ProducesResponseType(typeof(IList<Request>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllRequestByEmployee()
        {
            try
            {
                var employeeId = User.FindFirstValue(ClaimTypes.Name);
                if (employeeId == null)
                {
                    return BadRequest("Invalid User");
                }
                var RequestRaisedBy = Convert.ToInt32(employeeId);
                var requests = await _employeeRequestService.GetAllRequestByEmployee(RequestRaisedBy);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [Authorize]
        [HttpPost("ResponseToSolution")]
        [ProducesResponseType(typeof(RequestSolution), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResponseToSolution(ResponseToSolutionDTO responseToSolutionDTO)
        {
            try
            {
                var _requestSolution = await _employeeRequestService.ResponseToSolution(responseToSolutionDTO.SolutionId, responseToSolutionDTO.Response);
                return Ok(_requestSolution);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }

        [Authorize]

        [HttpGet("GetAllRequestByStatusOfEmployee")]
        [ProducesResponseType(typeof(IList<Request>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllRequestByStatus(string status)
        {
            try
            {
                var employeeId = User.FindFirstValue(ClaimTypes.Name);
                if (employeeId == null)
                {
                    return BadRequest("Invalid User");
                }
                var RequestRaisedBy = Convert.ToInt32(employeeId);
                var requests = await _employeeRequestService.GetAllRequestByStatus(RequestRaisedBy, status);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("AcceptSolution")]
        [ProducesResponseType(typeof(RequestSolution), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AcceptSolution(int solutionId)
        {
            try
            {
                var _requestSolution = await _employeeRequestService.AcceptSolution(solutionId);
                return Ok(_requestSolution);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
