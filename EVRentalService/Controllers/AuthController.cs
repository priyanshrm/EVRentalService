using EVRentalBusiness.Service;
using EVRentalEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EVRentalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        AuthService _authService = null;
        private readonly ILogger<AuthController> _logger;

        public AuthController(AuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpGet("Hello2")]
        public IActionResult Hello()
        {
            return Ok("Hello !! Application is Up.");
        }


        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser([FromBody] UserModel user)
        {
            try
            {
                _logger.LogInformation("Seri Log working: Adding User...");
                object result = _authService.RegisterUser(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error while adding user: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("LoginUser")]
        public IActionResult LoginUser(UserDTO request)
        {
            try
            {
                _logger.LogInformation("Seri Log working: Adding User...");
                object result = _authService.LoginUser(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error while adding user: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }



    }
}
