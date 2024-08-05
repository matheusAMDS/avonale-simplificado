using AvonaleSimplificado.Domain.Accounts;

public record AccountDTO(Guid Id, Guid UserId, double Balance)
{
    public static AccountDTO From(Account account)
    {
        return new AccountDTO(account.Id.Value, account.UserId.Value, account.Balance.Value);
    }
}
