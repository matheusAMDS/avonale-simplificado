using AvonaleSimplificado.Domain.Accounts;
using AvonaleSimplificado.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasConversion(
            id => id.Value,
            value => new TransactionId(value)
        );

        builder.Property(e => e.Amount).HasConversion(
            amount => amount.Value,
            value => new Money(value)
        );

        builder.Property(e => e.Type);

        builder.Property(e => e.CreatedAt);

        builder.HasOne<Account>()
            .WithMany()
            .HasForeignKey(e => e.FromAccount);

        builder.HasOne<Account>()
            .WithMany()
            .HasForeignKey(e => e.ToAccount);
    }
}
