using AvonaleSimplificado.Domain.Common;
using AvonaleSimplificado.Domain.Users;

namespace AvonaleSimplificado.Domain.Accounts.Services;

public interface IAccountService
{
    public Task<AccountId> CreateAccountAsync(UserId userId);

    public Task MakeTransferAsync(AccountId fromAccount, AccountId toAccount, Money amount);

    public Task MakeDepositAsync(AccountId toAccount, Money amount);
}
