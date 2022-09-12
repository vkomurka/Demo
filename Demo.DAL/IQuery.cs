namespace Demo.DAL;

public interface IQuery
{
}

public interface IQuery<TResult> : IQuery
{
    Task<List<TResult>> ExecuteAsync(IUnitOfWork unitOfWork);
}