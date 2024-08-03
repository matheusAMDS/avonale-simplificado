using AvonaleSimplificado.Domain.Users;
using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

// using AvonaleSimplificado.Infrastructure.Persistence.Identity;

namespace AvonaleSimplificado.Infrastructure.Persistence.Contexts;

// public class ApplicationDbContext : IdentityDbContext<UserEntity, IdentityRole<Guid>, Guid>
public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
