using AvonaleSimplificado.Domain.Common;
using AvonaleSimplificado.Domain.Users;

namespace AvonaleSimplificado.Domain.Accounts.Services;

public interface IAccountService
{
    public Task<Account?> GetAccountFromUserAsync(UserId userId);

    public Task<AccountExtract> GetAccountExtract(AccountId id, DateTime fromDate, DateTime toDate);

    public Task<AccountId> CreateAccountAsync(UserId userId);

    public Task MakeTransferAsync(AccountId fromAccount, AccountId toAccount, Money amount, CancellationToken token);

    public Task MakeDepositAsync(AccountId toAccount, Money amount, CancellationToken token);
}
