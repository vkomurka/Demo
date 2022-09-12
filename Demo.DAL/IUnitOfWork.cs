namespace Demo.DAL;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity, new();

    Task<List<TResult>> Query<TResult>(IQuery<TResult> query);
    Task<int> Command(ICommand command);

    Task Commit();
}