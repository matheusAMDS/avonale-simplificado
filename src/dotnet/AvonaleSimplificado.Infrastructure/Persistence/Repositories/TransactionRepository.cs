using AvonaleSimplificado.Domain.Accounts;
using AvonaleSimplificado.Domain.Accounts.Repositories;
using AvonaleSimplificado.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AvonaleSimplificado.Infrastructure.Persistence.Repositories;

public class TransactionRepository : BaseRepository<Transaction, TransactionId>, ITransactionRepository
{
    private readonly ApplicationDbContext _context;

    public TransactionRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Transaction>> GellAllByAccount(AccountId accountId)
    {
        return await _context.Transactions
            .Where(e => e.FromAccount == accountId || e.ToAccount == accountId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Transaction>> GetAllByAccountFromPeriod(AccountId accountId, DateTime start, DateTime end)
    {
        return await _context.Transactions
            .Where(e => e.FromAccount == accountId || e.ToAccount == accountId)
            .Where(e => e.CreatedAt > start && e.CreatedAt < end)
            .ToListAsync();
    }
}
