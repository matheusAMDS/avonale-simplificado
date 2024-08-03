using AvonaleSimplificado.Application.Users;
using AvonaleSimplificado.Domain.Users.Services;

namespace AvonaleSimplificado.WebAPI.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
