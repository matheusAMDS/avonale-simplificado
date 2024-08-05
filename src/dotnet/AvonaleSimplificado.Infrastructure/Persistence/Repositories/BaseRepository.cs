using AvonaleSimplificado.Domain.Common.Repositories;
using AvonaleSimplificado.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AvonaleSimplificado.Infrastructure.Persistence.Repositories;

public abstract class BaseRepository<TEntity, TPrimaryKey> : IBaseRepository<TEntity, TPrimaryKey>
    where TEntity : class
{
    private readonly ApplicationDbContext _dbContext;

    public BaseRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(TPrimaryKey id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity?> UpdateAsync(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<bool> DeleteAsync(TPrimaryKey id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null) return false;

        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    protected IQueryable<TEntity> Paginate(IQueryable<TEntity> query, int page, int pageSize)
    {
        return query
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
    }
}
