using Demo.DAL;
using SQLite;

namespace Demo.SQLite;

public abstract class QueryBase<TResult> : IQuery<TResult>
{
    protected SQLiteConnection Connection { get; set; }

    public Task<List<TResult>> Execute(IUnitOfWork unitOfWork)
    {
        Connection = ((UnitOfWork)unitOfWork).Connection;
        return Task.FromResult(GetRecords().ToList());
    }

    protected abstract IQueryable<TResult> GetRecords();
}