using AvonaleSimplificado.Domain.Common.Repositories;
using AvonaleSimplificado.Domain.Users;

namespace AvonaleSimplificado.Domain.Accounts.Repositories;

public interface IAccountRepository : IBaseRepository<Account, AccountId>
{
    public Task<Account?> GetByUserId(UserId userId);
}
