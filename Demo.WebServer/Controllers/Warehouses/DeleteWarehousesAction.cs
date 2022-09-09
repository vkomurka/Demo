using Demo.DAL.Actions;
using Demo.DAL.Interfaces;
using Demo.WebServer.Entities;

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
            await uow.Repository<Warehouse>().DeleteAsync(id);
            await uow.CommitAsync();
        }
    }
}