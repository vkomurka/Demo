using Demo.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL
{
    public abstract class QueryBase<TResult> : IQuery<TResult>
    {
        protected DbContext Context { get; set; }

        public Task<List<TResult>> ExecuteAsync(IUnitOfWork unitOfWork)
        {
            Context = ((UnitOfWork)unitOfWork).Context;
            return GetRecords().ToListAsync();
        }

        protected abstract IQueryable<TResult> GetRecords();
    }
}
