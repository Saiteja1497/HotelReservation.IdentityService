using AutoMapper;
using IdentityService.Core.DTO;
using IdentityService.Core.Entities;
using IdentityService.Core.RepositoryContracts;
using IdentityService.Core.UserContracts;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<AuthResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await _userRepository.GetUserByEmail(loginRequest.Email,  loginRequest.Password);
            if (user == null)
            {
                return null;
            }
            return _mapper.Map<AuthResponse>(user) with {Success=true, Token="token" };
            //return new AuthResponse( user.UserID, user.UserName, user.Email, user.Gender, "Token", Success: true);
        }

        public async Task<AuthResponse?> Register([FromBody] RegisterRequest registerRequest)
        {
            ApplicationUser user = _mapper.Map<ApplicationUser>(registerRequest);

            ApplicationUser? registeredUser = await _userRepository.AddUser(user);

            if (registeredUser == null)
            {
                return null;
            }
            return _mapper.Map<AuthResponse>(registeredUser) with { Success = true, Token = "token" };
            //return new AuthResponse(registeredUser.UserID, registeredUser.UserName, registeredUser.Email, registeredUser.Gender, "Token", Success: true);
        }
    }
}
