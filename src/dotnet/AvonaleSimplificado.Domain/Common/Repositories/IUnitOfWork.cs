namespace AvonaleSimplificado.Domain.Common;

public interface IUnitOfWork : IDisposable
{
    public Task BeginTransaction(CancellationToken token = default);

    public Task Commit(CancellationToken token);

    public Task Rollback();
}
