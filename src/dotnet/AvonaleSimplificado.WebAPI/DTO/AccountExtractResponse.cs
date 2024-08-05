using AvonaleSimplificado.Domain.Accounts;

namespace AvonaleSimplificado.WebAPI.DTO;

public record AccountExtractResponse(
    DateTime FromDate,
    DateTime ToDate,
    Guid AccountId,
    IEnumerable<TransactionDTO> Transactions,
    double Total
)
{
    public static AccountExtractResponse From(AccountExtract extract)
    {
        return new AccountExtractResponse(
            extract.FromDate,
            extract.ToDate,
            extract.AccountId.Value,
            extract.Transactions.Select(transaction => TransactionDTO.From(transaction)),
            extract.Total
        );
    }
}
