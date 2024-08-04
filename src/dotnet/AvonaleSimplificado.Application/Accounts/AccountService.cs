using AvonaleSimplificado.Domain.Accounts;
using AvonaleSimplificado.Domain.Accounts.Repositories;
using AvonaleSimplificado.Domain.Accounts.Services;
using AvonaleSimplificado.Domain.Common;
using AvonaleSimplificado.Domain.Users;

namespace AvonaleSimplificado.Application.Accounts;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUserRepository _userRepository;

    public AccountService(IAccountRepository accountRepository, IUserRepository userRepository)
    {
        _accountRepository = accountRepository;
        _userRepository = userRepository;
    }

    public async Task<AccountId> CreateAccountAsync(UserId userId)
    {
        var existingUser = await _userRepository.GetByIdAsync(userId);
        if (existingUser is null)
        {
            throw new Exception("User not found");
        }

        var newAccount = await _accountRepository.AddAsync(
            new Account(userId)
        );

        return newAccount.Id;
    }

    public Task MakeDepositAsync(AccountId toAccount, Money amount)
    {
        throw new NotImplementedException();
    }

    public Task MakeTransferAsync(AccountId fromAccount, AccountId toAccount, Money amount)
    {
        throw new NotImplementedException();
    }

}
