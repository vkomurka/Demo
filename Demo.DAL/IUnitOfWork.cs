namespace Demo.DAL;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity;

    Task<List<TResult>> QueryAsync<TResult>(IQuery<TResult> query);
    Task<int> CommandAsync(ICommand command);

    Task CommitAsync();
}