using Demo.DAL;
using Demo.WebServer.Model.Entities;

namespace Demo.WebServer.Controllers.Warehouses;

public class DeleteWarehousesAction : DatabaseAction
{
    public DeleteWarehousesAction(Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
    {
    }

    public async Task ExecuteAsync(Guid id)
    {
        using (var uow = UnitOfWorkFactory.Invoke())
        {
            await uow.Repository<Warehouse>().Delete(id);
            await uow.Commit();
        }
    }
}