namespace AvonaleSimplificado.Domain.Common.Repositories;

public interface IBaseRepository<TEntity, TPrimaryKey> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity?> GetByIdAsync(TPrimaryKey id);

    Task<TEntity> AddAsync(TEntity entity);

    Task<TEntity?> UpdateAsync(TEntity entity);

    Task<bool> DeleteAsync(TPrimaryKey id);
}
