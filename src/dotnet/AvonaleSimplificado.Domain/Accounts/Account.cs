using AvonaleSimplificado.Domain.Common;

namespace AvonaleSimplificado.Domain.Accounts
{
    public class Account
    {
        public AccountId Id { get; private set; }

        public Money Balance { get; private set; }

        public Account()
        {
            Id = new AccountId(Guid.NewGuid());
            Balance = new Money(0);
        }

        public Account(Guid value)
        {
            Id = new AccountId(value);
            Balance = new Money(0);
        }
    }
}
