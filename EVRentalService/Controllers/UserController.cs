using EVRentalBusiness.Service;
using EVRentalEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EVRentalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService _userService = null;
        private readonly ILogger<UserController> _logger;

        public UserController(UserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] UserModel user) 
        {
            try
            {
                _logger.LogInformation("Seri Log working: Adding User...");
                object result = _userService.AddUser(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error while adding user: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetUsers()
        {
            try
            {
                _logger.LogInformation("Seri log working: Fetching users...");
                object result = _userService.GetAllUser();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error while fetching user: {ex.Message}");
                return StatusCode(500, "internal Server Error");
            }
        }

        [HttpGet("GetUserById")]

        public IActionResult GetUserById(int id)
        {
            try
            {
                _logger.LogInformation($"Seri log working: Fetching user...{id}");
                object result = _userService.GetUserById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error while fetching user: {ex.Message}");
                return StatusCode(500, "internal server error");
            }
        }

        [HttpDelete("DeleteAllUsers")]
        public IActionResult DeleteAllUsers()
        {
            try
            {
                _logger.LogInformation($"Seri log working: Deleting users...");
                object result = _userService.DeletAllUser();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error while deleting user: {ex.Message}");
                return StatusCode(500, "internal server error");
            }
        }

        [HttpDelete("DeleteUserById")]
        public IActionResult DeleteUserById(int id)
        {
            try
            {
                _logger.LogInformation($"Seri log working: Deleting user... {id}");
                object result = _userService.DeletUserById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error while deleting user: {ex.Message}");
                return StatusCode(500, "internal server error");
            }
        }

        [HttpPut("UpdateUser")]

        public IActionResult UpdateUser(UserModel user)
        {
            try
            {
                _logger.LogInformation($"Seri log working: Updating user... {user.userId}");
                object result = _userService.UpdateUser(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error while updating user: {ex.Message}");
                return StatusCode(500, "internal server error");
            }
        }


    }
}
