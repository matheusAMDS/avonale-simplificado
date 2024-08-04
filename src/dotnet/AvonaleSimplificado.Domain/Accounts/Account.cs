using AvonaleSimplificado.Domain.Common;
using AvonaleSimplificado.Domain.Users;

namespace AvonaleSimplificado.Domain.Accounts
{
    public class Account
    {
        public AccountId Id { get; private set; }

        public UserId UserId { get; private set; }

        public Money Balance { get; private set; }

        public Account() { }

        public Account(UserId userId)
        {
            Id = new AccountId(Guid.NewGuid());
            Balance = new Money(0);
            UserId = userId;
        }

        public void Debit(Money amount)
        {
            Balance = Money.Sum(Balance, amount);
        }

        public void Credit(Money amount)
        {
            Balance = Money.Sub(Balance, amount);
        }
    }
}
