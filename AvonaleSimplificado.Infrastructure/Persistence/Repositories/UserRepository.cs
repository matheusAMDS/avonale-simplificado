using AvonaleSimplificado.Domain.Users;
using AvonaleSimplificado.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AvonaleSimplificado.Infrastructure.Persistence.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<User> AddUserAsync(User user)
    {
        context.Users.Add(user);

        await context.SaveChangesAsync();

        return user;
    }

    public async Task<User?> GetUserByCPFAsync(CPF cpf)
    {
        return await context.Users
            .FirstOrDefaultAsync(user => user.CPF == cpf);
    }

    public async Task<User?> GetUserByEmailAsync(Email email)
    {
        return await context.Users
            .FirstOrDefaultAsync(user => user.Email == email);
    }

    public async Task<User?> GetUserByIdAsync(UserId id)
    {
        return await context.Users
            .FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await context.Users.ToListAsync();
    }
}
