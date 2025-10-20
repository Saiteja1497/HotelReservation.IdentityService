using IdentityService.Core.DTO;
using IdentityService.Core.Entities;

namespace IdentityService.Core.UserContracts
{
    public interface IUsersService
    {
        Task<AuthResponse?> Login(LoginRequest loginRequest);
        Task<AuthResponse?> Register(RegisterRequest registerRequest);

    }
}
