using System.Linq.Expressions;

namespace Demo.DAL;

public interface IRepository<TEntity>
    where TEntity : class, IEntity
{
    Task Add(TEntity entity);
    Task Add(IEnumerable<TEntity> entities);

    Task Update(TEntity entity);
    Task Update(IEnumerable<TEntity> entities);

    Task Delete(Guid id);
    Task Delete(TEntity entity);
    Task Delete(IEnumerable<TEntity> entities);

    Task<List<TEntity>> Get();
    Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
}