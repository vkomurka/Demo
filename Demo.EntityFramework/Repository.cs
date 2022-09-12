using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Demo.DAL;

namespace Demo.EntityFramework
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public Repository(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected DbContext Context { get; }

        public async Task Add(TEntity entity)
        {
            await Context.AddAsync(entity);
        }

        public async Task Add(IEnumerable<TEntity> entities)
        {
            await Context.AddRangeAsync(entities);
        }

        public async Task Delete(Guid id)
        {
            var entity = await FirstOrDefault(c => c.Id == id);
            await Delete(entity);
        }

        public async Task Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            await Task.CompletedTask;
        }

        public async Task Delete(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            await Task.CompletedTask;
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> Get()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            await Task.CompletedTask;
        }

        public async Task Update(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().UpdateRange(entities);
            await Task.CompletedTask;
        }
    }
}
