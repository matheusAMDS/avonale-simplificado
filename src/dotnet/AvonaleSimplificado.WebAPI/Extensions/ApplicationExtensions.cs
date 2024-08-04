using AvonaleSimplificado.Application.Accounts;
using AvonaleSimplificado.Application.Users;
using AvonaleSimplificado.Domain.Accounts.Services;
using AvonaleSimplificado.Domain.Users.Services;

namespace AvonaleSimplificado.WebAPI.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAccountService, AccountService>();

        return services;
    }
}
