using Demo.DAL;
using SQLite;

namespace Demo.SQLite;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(SQLiteConnection connection)
    {
        Connection = connection ?? throw new ArgumentNullException(nameof(connection));
        Connection.BeginTransaction();
    }

    public SQLiteConnection Connection { get; }

    protected Dictionary<Type, object> Repositories { get; set; }
    private bool Disposed = false;


    public async Task<int> Command(ICommand command)
    {
        return await command.Execute(this);
    }

    public async Task Commit()
    {
        Connection.Commit();
        await Task.CompletedTask;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!Disposed)
        {
            if (disposing)
            {
                if (Repositories != null)
                {
                    Repositories.Clear();
                }
                Connection.Dispose();
            }
        }
        Disposed = true;
    }

    public async Task<List<TResult>> Query<TResult>(IQuery<TResult> query)
    {
        return await query.Execute(this);
    }

    public IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity, new()
    {
        if (Repositories == null)
        {
            Repositories = new Dictionary<Type, object>();
        }

        var type = typeof(TEntity);
        if (!Repositories.ContainsKey(type))
        {
            Repositories[type] = new Repository<TEntity>(Connection);
        }
        return (IRepository<TEntity>)Repositories[type];
    }
}