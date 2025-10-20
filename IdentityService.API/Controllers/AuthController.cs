using IdentityService.Core.DTO;
using IdentityService.Core.UserContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IUsersService usersService, ILogger<AuthController> logger)
        {
            _usersService = usersService;
            _logger = logger;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if(registerRequest == null) throw new ArgumentNullException(nameof(registerRequest));

            AuthResponse authResponse = await _usersService.Register(registerRequest);

            if (authResponse == null|| authResponse.Success==false)
            {
                return BadRequest(authResponse);
            }
            return Ok(authResponse);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if(loginRequest == null) throw new ArgumentNullException( nameof(loginRequest));

            AuthResponse authResponse=await _usersService.Login(loginRequest);

            if(authResponse == null|| authResponse.Success==false) { return Unauthorized(authResponse); }
            return Ok(authResponse);


        }
    }
}
