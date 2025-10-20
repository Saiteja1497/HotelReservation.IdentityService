using IdentityService.Core.Entities;

namespace IdentityService.Core.RepositoryContracts
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> AddUser(ApplicationUser user);
        Task<ApplicationUser?> GetUserByEmail(string? email, string? password);

    }
}
