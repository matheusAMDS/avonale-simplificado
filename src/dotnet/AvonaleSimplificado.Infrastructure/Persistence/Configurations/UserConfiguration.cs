using AvonaleSimplificado.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvonaleSimplificado.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasConversion(
            userId => userId.Value,
            value => new UserId(value)
        );

        builder.Property(e => e.Type).HasConversion<int>();

        builder.OwnsOne(e => e.Name, nameBuilder =>
        {
            nameBuilder.Property(p => p.FirstName).HasColumnName("FirstName");

            nameBuilder.Property(p => p.LastName).HasColumnName("LastName");
        });

        builder.HasIndex(e => e.Email).IsUnique();
        builder.Property(e => e.Email).HasConversion(
            email => email.Value,
            value => new Email(value)
        );

        builder.Property(e => e.Password).HasConversion<string>(
            password => password.Value,
            value => new Password(value)
        );

        builder.HasIndex(e => e.CPF).IsUnique();
        builder.Property(e => e.CPF)
            .HasConversion<string>(
                cpf => cpf.Value,
                value => new CPF(value)
            )
            .HasMaxLength(11)
            .IsFixedLength();

        // this.Seed(builder);
    }

    // public void Seed(EntityTypeBuilder<User> builder)
    // {
    //     var hashingService = new HashingService();

    //     builder.HasData(
    //         new
    //         {
    //             Id = new UserId(Guid.NewGuid()),
    //             Type = UserType.Admin,
    //             FirstName = "Administrador",
    //             LastName = "Avonale",
    //             Email = new Email("admin@email.com"),
    //             Password = new Password(hashingService.Hash("Admin123@")),
    //             CPF = new CPF("10574073051")
    //         }
    //     );
    // }

}
