using Demo.DAL;
using Microsoft.EntityFrameworkCore;

namespace Demo.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public DbContext Context { get; protected set; }

        protected Dictionary<Type, object> Repositories { get; set; }
        private bool Disposed = false;


        public async Task<int> CommandAsync(ICommand command)
        {
            return await command.ExecuteAsync(this);
        }

        public async Task CommitAsync()
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

        public async Task<List<TResult>> QueryAsync<TResult>(IQuery<TResult> query)
        {
            return await query.ExecuteAsync(this);
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity
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
}
