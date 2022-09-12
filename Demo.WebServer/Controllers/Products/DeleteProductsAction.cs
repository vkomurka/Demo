using Demo.EntityFramework.Actions;
using Demo.EntityFramework.Interfaces;
using Demo.WebServer.Entities;

namespace Demo.WebServer.Controllers.Products;

public class DeleteProductsAction : DatabaseAction
{
    public DeleteProductsAction(Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
    {
    }

    public async Task ExecuteAsync(Guid id)
    {
        using (var uow = UnitOfWorkFactory.Invoke())
        {
            await uow.Repository<Product>().DeleteAsync(id);
            await uow.CommitAsync();
        }
    }
}
