using AvonaleSimplificado.Application.Abstractions;
using AvonaleSimplificado.Domain.Accounts.Repositories;
using AvonaleSimplificado.Domain.Users;
using AvonaleSimplificado.Infrastructure.Persistence.Contexts;
using AvonaleSimplificado.Infrastructure.Persistence.Repositories;
using AvonaleSimplificado.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace AvonaleSimplificado.WebAPI.Extensions;

public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("ApplicationContext"));
        });

        services.AddScoped<IHashingService, HashingService>();
        services.AddScoped<ITokenService, JwtTokenService>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();

        return services;
    }
}
