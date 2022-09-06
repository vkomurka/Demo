using Demo.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL
{
    public abstract class CommandBase : ICommand
    {
        public async Task<int> ExecuteAsync(IUnitOfWork unitOfWork)
        {
            return await ExecuteSqlCommandAsync(((UnitOfWork)unitOfWork).Context);
        }

        protected abstract Task<int> ExecuteSqlCommandAsync(DbContext context);
    }
}
