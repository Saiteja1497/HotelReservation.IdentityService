using IdentityService.Core.RepositoryContracts;
using IdentityService.Infrastructure.DbContext;
using IdentityService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<DapperDbContext>();
            return services;
        }
    }
}
