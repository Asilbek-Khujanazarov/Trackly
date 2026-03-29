using Microsoft.AspNetCore.Mvc;
using Trackly.Application.DTOs.Auth;
using Trackly.Infrastructure.Services;

namespace Trackly.Api.Controllers.Auth
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            await _authService.Register(dto);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _authService.Login(dto);
            if(result == null)
            {
                return Unauthorized("Invalid credentials");
            }
            return Ok(result);
        }

        [HttpPost("refresh")]
        public async  Task<IActionResult> Refresh(RefreshRequestDto dto)
        {
            var result = await _authService.Refresh(dto.RefreshToken);
            return Ok(result);
        }
    }
}
