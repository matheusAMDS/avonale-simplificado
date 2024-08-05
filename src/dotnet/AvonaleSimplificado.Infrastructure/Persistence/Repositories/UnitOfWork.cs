using AvonaleSimplificado.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace AvonaleSimplificado.Domain.Common.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private IDbContextTransaction? _transaction;
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task BeginTransaction(CancellationToken cancellationToken = default)
    {
        _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task Commit(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
        if (_transaction is not null)
            await _transaction.CommitAsync();
    }

    public void Dispose()
    {
        if (_transaction is not null)
            _transaction.DisposeAsync();
    }

    public async Task Rollback()
    {
        if (_transaction is not null)
            await _transaction.RollbackAsync();
    }
}
