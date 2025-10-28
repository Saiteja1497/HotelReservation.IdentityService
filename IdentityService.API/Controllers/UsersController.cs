using IdentityService.Core.DTO;
using IdentityService.Core.UserContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService) 
        {
            _usersService = usersService;
        }
        [HttpGet("{userID}")]
        public async Task<IActionResult> Get(Guid userID)
        {
            if(userID==Guid.Empty)
            {
                return BadRequest("UserID is invalid");
            }
            UserDTO? user =await _usersService.GetUserByUserID(userID);
            if(user==null)
            {
                return NotFound(user);
            }
            return Ok(user);
        }
    }
}
