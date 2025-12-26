using AIUX.DTOs;
using AIUX.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AIUX.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]

        public async Task<ActionResult>Register(RegisterUserDto registerUserDto)
        {
            if (await _userService.IsTakenEmailAsync(registerUserDto.Email)) 
                return BadRequest("Email is already taken!");

            await _userService.RegisterAsync(registerUserDto);

            return NoContent();
        }

        [HttpPost("login")]

        public async Task<ActionResult<LoginResponseDto>>Login(LoginUserDto loginUserDto)
        {
            var token = await _userService.LoginAsync(loginUserDto);

            if (token is null)
                return Unauthorized();

            var response = new LoginResponseDto(token);

            
            return Ok(response);
        }

    }
}
