using Demo.DAL;
using Demo.WebServer.Model.Entities;

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
            await uow.Repository<Uom>().Delete(id);
            await uow.Commit();
        }
    }
}
