using System.Linq.Expressions;
using Demo.Entities;

namespace Demo.DAL.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        Task AddAsync(TEntity entity);
        Task AddAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);

        Task DeleteAsync(Guid id);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);

        Task<List<TEntity>> GetAsync();
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
