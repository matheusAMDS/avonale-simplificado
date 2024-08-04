using AvonaleSimplificado.Domain.Accounts;
using AvonaleSimplificado.Domain.Accounts.Repositories;
using AvonaleSimplificado.Infrastructure.Persistence.Contexts;
using AvonaleSimplificado.Infrastructure.Persistence.Repositories;

public class AccountRepository : BaseRepository<Account, AccountId>, IAccountRepository
{
    private readonly ApplicationDbContext _context;

    public AccountRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
