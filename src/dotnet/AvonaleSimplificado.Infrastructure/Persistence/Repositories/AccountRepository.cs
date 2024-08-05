using AvonaleSimplificado.Domain.Accounts;
using AvonaleSimplificado.Domain.Accounts.Repositories;
using AvonaleSimplificado.Domain.Users;
using AvonaleSimplificado.Infrastructure.Persistence.Contexts;
using AvonaleSimplificado.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

public class AccountRepository : BaseRepository<Account, AccountId>, IAccountRepository
{
    private readonly ApplicationDbContext _context;

    public AccountRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Account?> GetByUserId(UserId userId)
    {
        return await _context.Accounts.FirstOrDefaultAsync(e => e.UserId == userId);
    }
}
