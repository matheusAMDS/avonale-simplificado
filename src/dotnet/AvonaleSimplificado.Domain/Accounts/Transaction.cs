using AvonaleSimplificado.Domain.Common;

namespace AvonaleSimplificado.Domain.Accounts;

public class Transaction
{
    public TransactionId Id { get; private set; }

    public TransactionType Type { get; private set; } = TransactionType.Deposit;

    public AccountId? FromAccount { get; private set; }

    public AccountId ToAccount { get; private set; } = null!;

    public Money Amount { get; private set; } = new Money(0);

    public DateTime CreatedAt { get; private set; }

    public Transaction() { }

    private Transaction(TransactionType type, AccountId? fromAccount, AccountId toAccount, Money amount)
    {
        Id = new TransactionId(Guid.NewGuid());
        Type = type;
        FromAccount = fromAccount;
        ToAccount = toAccount;
        Amount = amount;
        CreatedAt = DateTime.UtcNow;
    }

    public static Transaction NewDeposit(AccountId toAccount, Money amount)
    {
        var transaction = new Transaction(
            TransactionType.Deposit,
            null,
            toAccount,
            amount
        );

        return transaction;
    }

    public static Transaction NewTransfer(AccountId fromAccount, AccountId toAccount, Money amount)
    {
        var transaction = new Transaction(
            TransactionType.Transfer,
            fromAccount,
            toAccount,
            amount
        );

        return transaction;
    }
}
