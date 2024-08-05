using AvonaleSimplificado.Domain.Accounts;
using AvonaleSimplificado.Domain.Common;
using AvonaleSimplificado.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvonaleSimplificado.Infrastructure.Persistence.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasConversion(
            id => id.Value,
            value => new AccountId(value)
        );

        builder.Property(e => e.Balance).HasConversion(
            balance => balance.Value,
            value => new Money(value)
        );

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
