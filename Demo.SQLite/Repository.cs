using System.Linq.Expressions;
using Demo.Entities;
using SQLite.Net.Async;

namespace Demo.SQLite;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    private SQLiteAsyncConnection db;


    public async Task AddAsync(TEntity entity)
    {
        await db.InsertAsync(entity);
    }

    public async Task AddAsync(IEnumerable<TEntity> entities)
    {
        await db.InsertAllAsync(entities);
    }

    public async Task Update(TEntity entity)
    {
        await db.UpdateAsync(entity);
    }

    public async Task Update(IEnumerable<TEntity> entities)
    {
        await db.UpdateAllAsync(entities);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await FirstOrDefaultAsync(c => c.Id == id);
        await Delete(entity);
    }

    public async Task Delete(TEntity entity)
    {
        await db.DeleteAsync(entity);
    }

    public async Task Delete(IEnumerable<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            await Delete(entity);
        }
    }

    public Task<List<TEntity>> GetAsync()
    {
        return db.Table<TEntity>().ToListAsync();
    }

    public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var query = db.Table<TEntity>();

        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        return await query.ToListAsync();
    }

    public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await db.FindAsync(predicate);
    }
}