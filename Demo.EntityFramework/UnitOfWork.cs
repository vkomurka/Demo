using Demo.DAL;
using Microsoft.EntityFrameworkCore;

namespace Demo.EntityFramework;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(DbContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public DbContext Context { get; protected set; }

    protected Dictionary<Type, object> Repositories { get; set; }
    private bool Disposed = false;


    public async Task<int> Command(ICommand command)
    {
        return await command.Execute(this);
    }

    public async Task Commit()
    {
        await Context.SaveChangesAsync();
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
                Context.Dispose();
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
            Repositories[type] = new Repository<TEntity>(Context);
        }
        return (IRepository<TEntity>)Repositories[type];
    }
}