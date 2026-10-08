using Microsoft.AspNetCore.Mvc;
using MovieFlix.Api.DTOs.Auth;
using MovieFlix.Api.Services;

namespace MovieFlix.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            await _authService.RegisterAsync(request);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(
            LoginRequest request)
        {
            var response = await _authService.LoginAsync(request);

            if (response is null)
            {
                return Unauthorized();
            }

            return Ok(response);
        }
    }
}
