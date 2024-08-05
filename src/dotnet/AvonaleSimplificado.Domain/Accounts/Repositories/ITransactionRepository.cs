using AvonaleSimplificado.Domain.Common.Repositories;

namespace AvonaleSimplificado.Domain.Accounts.Repositories;

public interface ITransactionRepository : IBaseRepository<Transaction, TransactionId>
{
    public Task<IEnumerable<Transaction>> GellAllByAccount(AccountId accountId);

    public Task<IEnumerable<Transaction>> GetAllByAccountFromPeriod(AccountId accountId, DateTime start, DateTime end);
}
