using Microsoft.AspNetCore.Mvc;
using StudentManagementFile.API.Models;
using StudentManagementFile.API.Models.DTOs;
using StudentManagementFile.API.Services;

namespace StudentManagementFile.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authSerivce;
        public AuthController(IAuthService authService)
        {
            _authSerivce = authService;
        }
        [HttpPost("register")]
        [ProducesResponseType(typeof(ApiResponse<AuthResponse>), 200)]
        [ProducesResponseType(typeof(ApiResponse<object>), 400)]
        public IActionResult Register([FromBody] RegisterRequest registerRequest)
        {
            if(!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(ApiResponse<object>.Fail(string.Join(" | ", errors)));
            }
            var result = _authSerivce.Register(registerRequest);
            if(result == null)
            {
                return BadRequest(ApiResponse<object>.Fail("Username or Email already exists."));
            }
            return Ok(ApiResponse<AuthResponse>.Ok(result,"User successfully registered"));
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(ApiResponse<AuthResponse>), 200)]
        [ProducesResponseType(typeof(ApiResponse<object>), 400)]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<object>.Fail("Invalid data"));
            }
            var result = _authSerivce.Login(loginRequest);
            if(result == null)
            {
                return BadRequest(ApiResponse<object>.Fail("Invalid username and password"));
            }
            return Ok(ApiResponse<AuthResponse>.Ok(result,"Login successful."));
        }
    }
}