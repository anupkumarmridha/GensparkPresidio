using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Models.DBModels;
using EmployeeRequestTrackerAPI.Models.DTOModels;
using EmployeeRequestTrackerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(LoginReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginReturnDTO>> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                var result = await _userService.Login(userLoginDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while logging in");
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }

        [Authorize(Roles="Admin")]
        [HttpPut("Activate")]
        [ProducesResponseType(typeof(ReturnUserActivationDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReturnUserActivationDTO>> UserActivate(UserActivationDTO userActivationDTO)
        {
            try
            {
                var result = await _userService.UserActivation(userActivationDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> Register(EmployeeRegisterDTO userDTO)
        {
            try
            {
                Employee result = await _userService.Register(userDTO);
                return Ok(result);
            }
            catch (UserAlreadyExistsException ex)
            {
                return Conflict(new ErrorModel(409, ex.Message));
            }
            catch (PasswordMismatchException ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
            catch (UnableToRegisterException ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, $"An unexpected error occurred {ex.Message}")); // Generic error handling
            }
        }
    }
}
