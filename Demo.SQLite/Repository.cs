using System.Linq.Expressions;
using Demo.DAL;
using SQLite;

namespace Demo.SQLite;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity, new()
{
    public SQLiteConnection Connection { get; }

    public Repository(SQLiteConnection connection)
    {
        Connection = connection ?? throw new ArgumentNullException(nameof(connection));
    }

    public async Task Init()
    {
        Connection.CreateTable<TEntity>();
        await Task.CompletedTask;
    }

    public async Task Add(TEntity entity)
    {
        Connection.Insert(entity);
        await Task.CompletedTask;
    }

    public async Task Add(IEnumerable<TEntity> entities)
    {
        Connection.InsertAll(entities);
        await Task.CompletedTask;
    }

    public async Task Update(TEntity entity)
    {
        Connection.Update(entity);
        await Task.CompletedTask;
    }

    public async Task Update(IEnumerable<TEntity> entities)
    {
        Connection.UpdateAll(entities);
        await Task.CompletedTask;
    }

    public async Task Delete(Guid id)
    {
        var entity = await FirstOrDefault(c => c.Id == id);
        await Delete(entity);
    }

    public async Task Delete(TEntity entity)
    {
        Connection.Delete(entity);
        await Task.CompletedTask;
    }

    public async Task Delete(IEnumerable<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            await Delete(entity);
        }
    }

    public async Task<List<TEntity>> Get()
    {
        return await Task.FromResult(Connection.Table<TEntity>().ToList());
    }

    public async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
    {
        var query = Connection.Table<TEntity>();

        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        return await Task.FromResult(query.ToList());
    }

    public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return await Task.FromResult(Connection.Find(predicate));
    }
}