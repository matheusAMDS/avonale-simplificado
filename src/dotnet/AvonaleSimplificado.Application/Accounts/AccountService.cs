using AvonaleSimplificado.Domain.Accounts;
using AvonaleSimplificado.Domain.Accounts.Repositories;
using AvonaleSimplificado.Domain.Accounts.Services;
using AvonaleSimplificado.Domain.Common;
using AvonaleSimplificado.Domain.Users;

namespace AvonaleSimplificado.Application.Accounts;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IUserRepository _userRepository;

    private readonly IUnitOfWork _unitOfWork;

    public AccountService(
        IAccountRepository accountRepository,
        IUserRepository userRepository,
        ITransactionRepository transactionRepository,
        IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository;
        _userRepository = userRepository;
        _transactionRepository = transactionRepository;

        _unitOfWork = unitOfWork;
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

    public async Task<AccountExtract> GetAccountExtract(AccountId id, DateTime fromDate, DateTime toDate)
    {
        var account = await _accountRepository.GetByIdAsync(id);
        if (account is null)
        {
            throw new Exception("Account not found");
        }

        var accountTransactions = await _transactionRepository.GetAllByAccountFromPeriod(id, fromDate, toDate);

        var accountExtract = AccountExtract.Create(fromDate, toDate, id, accountTransactions);

        return accountExtract;
    }

    public async Task<Account?> GetAccountFromUserAsync(UserId userId)
    {
        return await _accountRepository.GetByUserId(userId);
    }

    public async Task MakeDepositAsync(AccountId toAccount, Money amount, CancellationToken cancellationToken)
    {
        var destinyAccount = await _accountRepository.GetByIdAsync(toAccount);
        if (destinyAccount is null)
        {
            throw new Exception("Account not found");
        }

        destinyAccount.Debit(amount);

        var transaction = Transaction.NewDeposit(toAccount, amount);

        await _unitOfWork.BeginTransaction(cancellationToken);

        try
        {
            await _transactionRepository.AddAsync(transaction);

            await _accountRepository.UpdateAsync(destinyAccount);

            await _unitOfWork.Commit(cancellationToken);
        }
        catch
        {
            await _unitOfWork.Rollback();

            throw new Exception("Unable to finish transaction");
        }

        return;
    }

    public async Task MakeTransferAsync(AccountId fromAccount, AccountId toAccount, Money amount, CancellationToken cancellationToken)
    {
        var originAccount = await _accountRepository.GetByIdAsync(fromAccount);
        if (originAccount is null)
        {
            throw new Exception("Origin account not found");
        }

        var destinyAccount = await _accountRepository.GetByIdAsync(toAccount);
        if (destinyAccount is null)
        {
            throw new Exception("Destiny account not found");
        }

        originAccount.Credit(amount);
        destinyAccount.Debit(amount);

        var transaction = Transaction.NewTransfer(originAccount.Id, destinyAccount.Id, amount);

        await _unitOfWork.BeginTransaction(cancellationToken);

        try
        {
            await _accountRepository.UpdateAsync(originAccount);

            await _accountRepository.UpdateAsync(destinyAccount);

            await _transactionRepository.AddAsync(transaction);

            await _unitOfWork.Commit(cancellationToken);
        }
        catch (Exception ex)
        {
            await _unitOfWork.Rollback();

            throw new Exception("Unable to finish transaction");
        }

        return;
    }

}
