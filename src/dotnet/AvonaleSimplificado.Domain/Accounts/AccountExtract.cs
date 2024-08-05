namespace AvonaleSimplificado.Domain.Accounts;

public class AccountExtract
{
    public DateTime FromDate { get; private set; }
    public DateTime ToDate { get; private set; }
    public AccountId AccountId { get; private set; }
    public IEnumerable<Transaction> Transactions { get; private set; }
    public double Total { get; private set; }

    private AccountExtract(
        DateTime fromDate,
        DateTime toDate,
        AccountId accountId,
        IEnumerable<Transaction> transactions,
        double total
    )
    {
        FromDate = fromDate;
        ToDate = toDate;
        AccountId = accountId;
        Transactions = transactions;
        Total = total;
    }

    public static AccountExtract Create(
        DateTime fromDate,
        DateTime toDate,
        AccountId accountId,
        IEnumerable<Transaction> transactions
    )
    {
        if (fromDate >= toDate) throw new Exception("Invalid date period");

        return new AccountExtract(
            fromDate,
            toDate,
            accountId,
            transactions,
            transactions.Sum(transaction =>
            {
                if (transaction.ToAccount == accountId) return 0;
                return 0;
            })
        );
    }
}
