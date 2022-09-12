using Demo.DAL;
using Microsoft.EntityFrameworkCore;

namespace Demo.EntityFramework
{
    public abstract class QueryBase<TResult> : IQuery<TResult>
    {
        protected DbContext Context { get; set; }

        public Task<List<TResult>> Execute(IUnitOfWork unitOfWork)
        {
            Context = ((UnitOfWork)unitOfWork).Context;
            return GetRecords().ToListAsync();
        }

        protected abstract IQueryable<TResult> GetRecords();
    }
}
