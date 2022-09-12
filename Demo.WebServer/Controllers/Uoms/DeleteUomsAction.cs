using Demo.DAL;
using Demo.EntityFramework.Actions;
using Demo.WebServer.Entities;

namespace Demo.WebServer.Controllers.Uoms;

public class DeleteUomsAction : DatabaseAction
{
    public DeleteUomsAction(Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
    {
    }

    public async Task ExecuteAsync(Guid id)
    {
        using (var uow = UnitOfWorkFactory.Invoke())
        {
            await uow.Repository<Uom>().DeleteAsync(id);
            await uow.CommitAsync();
        }
    }
}
