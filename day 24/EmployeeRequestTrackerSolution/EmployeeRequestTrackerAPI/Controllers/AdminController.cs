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
    public class AdminController : ControllerBase
    {
        private readonly IAdminRequestService _adminRequestService;
        private readonly ILogger<AdminController> _logger;
        public AdminController(IAdminRequestService adminRequestService, ILogger<AdminController> logger)
        {
            _adminRequestService = adminRequestService;
            _logger = logger;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddRequestSolution")]
        [ProducesResponseType(typeof(RequestSolution), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RequestSolution>> AddRequestSolutionByAdmin(AdminRequestSolutionDTO adminRequestSolutionDTO)
        {
            try
            {
                var employeeId = User.FindFirstValue(ClaimTypes.Name);
                if (employeeId == null)
                {
                    return BadRequest(new ErrorModel(400, "Invalid User"));
                }
                var AdminEmployeeId = Convert.ToInt32(employeeId);
                var result = await _adminRequestService.AddRequestSolutionByAdmin(adminRequestSolutionDTO.RequestId, adminRequestSolutionDTO.SolutionDescription, AdminEmployeeId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding request solution");
                if (ex.InnerException != null)
                {
                    _logger.LogError(ex.InnerException, "Inner exception details");
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorModel(500, ex.Message));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllRequestsByStatus")]
        [ProducesResponseType(typeof(IList<Request>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Request>>> GetAllEmployeesRequestsByStatus(string status)
        {
            try
            {
                var employeeId = User.FindFirstValue(ClaimTypes.Name);
                if (employeeId == null)
                {
                    return BadRequest(new ErrorModel(400, "Invalid User"));
                }
                var AdminEmployeeId = Convert.ToInt32(employeeId);
                var result = await _adminRequestService.GetAllEmployeesRequestsByStatus(AdminEmployeeId, status);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching requests by status");
                if (ex.InnerException != null)
                {
                    _logger.LogError(ex.InnerException, "Inner exception details");
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorModel(500, ex.Message));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("CloseRequest")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> MarkedRequestCloseByAdmin(int requestId)
        {
            try
            {
                var employeeId = User.FindFirstValue(ClaimTypes.Name);
                if (employeeId == null)
                {
                    return BadRequest(new ErrorModel(400, "Invalid User"));
                }
                var AdminEmployeeId = Convert.ToInt32(employeeId);
                var result = await _adminRequestService.MarkedRequestCloseByAdmin(requestId, AdminEmployeeId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while closing the request");
                if (ex.InnerException != null)
                {
                    _logger.LogError(ex.InnerException, "Inner exception details");
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorModel(500, ex.Message));
            }
        }
    }
}
