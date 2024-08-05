using AvonaleSimplificado.Domain.Accounts;

namespace AvonaleSimplificado.WebAPI.DTO;

public record TransactionDTO(
    Guid Id,
    Guid? FromAccount,
    Guid ToAccount,
    double Amount,
    DateTime CreatedAt
)
{
    public static TransactionDTO From(Transaction transaction)
    {
        return new TransactionDTO(
            transaction.Id.Value,
            transaction.FromAccount != null ?
                transaction.FromAccount.Value
                : null,
            transaction.ToAccount.Value,
            transaction.Amount.Value,
            transaction.CreatedAt
        );
    }
}
