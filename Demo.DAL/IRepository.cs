using System.Linq.Expressions;

namespace Demo.DAL;

public interface IRepository<TEntity>
    where TEntity : class, IEntity
{
    Task AddAsync(TEntity entity);
    Task AddAsync(IEnumerable<TEntity> entities);

    Task Update(TEntity entity);
    Task Update(IEnumerable<TEntity> entities);

    Task DeleteAsync(Guid id);
    Task Delete(TEntity entity);
    Task Delete(IEnumerable<TEntity> entities);

    Task<List<TEntity>> GetAsync();
    Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
}