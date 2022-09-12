using Demo.DAL;
using SQLite;

namespace Demo.SQLite;

public abstract class CommandBase : ICommand
{
    public async Task<int> Execute(IUnitOfWork unitOfWork)
    {
        return await ExecuteSqlCommandAsync(((UnitOfWork)unitOfWork).Connection);
    }

    protected abstract Task<int> ExecuteSqlCommandAsync(SQLiteConnection connection);
}