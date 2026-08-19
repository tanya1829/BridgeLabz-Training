using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FundooNotesApp.Business.Interface;
using FundooNotesApp.ModelLayer.DTOs.Request;

namespace FundooNotesApp.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerDto)
        {
            var result = await _userService.RegisterAsync(registerDto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // POST api/user/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
        {
            var result = await _userService.LoginAsync(loginDto);

            if (!result.Success)
                return Unauthorized(result);

            return Ok(result);
        }

        // POST api/user/forgotpassword
        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestDto forgotPasswordDto)
        {
            var result = await _userService.ForgotPasswordAsync(forgotPasswordDto);
            return Ok(result);
        }

        // GET api/user/profile
        // [Authorize] = only accessible when a valid JWT token is sent in the Authorization header
        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            // Extract UserId from JWT claims (set during login in JwtTokenService)
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized(new { Success = false, Message = "Invalid token" });

            var userId = int.Parse(userIdClaim);
            var result = await _userService.GetProfileAsync(userId);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }
    }
}