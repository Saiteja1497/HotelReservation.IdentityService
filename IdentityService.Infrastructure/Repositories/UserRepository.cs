using Dapper;
using IdentityService.Core.DTO;
using IdentityService.Core.Entities;
using IdentityService.Core.RepositoryContracts;
using IdentityService.Infrastructure.DbContext;

namespace IdentityService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _dapperDbContext;
        public UserRepository(DapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserID= Guid.NewGuid();
            string query = "INSERT INTO public.\"Users\"(\"UserID\",\"Email\",\"UserName\",\"Gender\",\"Password\")" +
                "VALUES(@UserID,@Email,@UserName,@Gender,@Password)";
           int rowsAffected =  await _dapperDbContext.DbConnection.ExecuteAsync(query,user);
            if (rowsAffected > 0)
            {
                return user;
            }
            else { return null; }
            
        }

        public async Task<ApplicationUser?> GetUserByEmail(string? email, string? password)
        {

            string? query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
            var parameneters = new { Email = email, Password = password };
            ApplicationUser? user  = await _dapperDbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query,parameneters);
            return user;
        }
    }
}
