using AvonaleSimplificado.Domain.Users;
using AvonaleSimplificado.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AvonaleSimplificado.Infrastructure.Persistence.Repositories;

public class UserRepository : BaseRepository<User, UserId>, IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> AddUserAsync(User user)
    {
        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User?> GetUserByCPFAsync(CPF cpf)
    {
        return await _context.Users
            .FirstOrDefaultAsync(user => user.CPF == cpf);
    }

    public async Task<User?> GetUserByEmailAsync(Email email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(user => user.Email == email);
    }

    // public async Task<User?> GetUserByIdAsync(UserId id)
    // {
    //     return await _context.Users
    //         .FirstOrDefaultAsync(user => user.Id == id);
    // }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }
}
