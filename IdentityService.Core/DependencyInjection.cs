using FluentValidation;
using IdentityService.Core.Services;
using IdentityService.Core.UserContracts;
using IdentityService.Core.Validators;
using Microsoft.Extensions.DependencyInjection;
namespace IdentityService.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<IUsersService, UsersService>();
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            return services;
        }
    }
}
