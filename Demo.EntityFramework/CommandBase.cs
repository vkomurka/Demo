using Demo.DAL;
using Microsoft.EntityFrameworkCore;

namespace Demo.EntityFramework;

public abstract class CommandBase : ICommand
{
    public async Task<int> Execute(IUnitOfWork unitOfWork)
    {
        return await ExecuteSqlCommandAsync(((UnitOfWork)unitOfWork).Context);
    }

    protected abstract Task<int> ExecuteSqlCommandAsync(DbContext context);
}