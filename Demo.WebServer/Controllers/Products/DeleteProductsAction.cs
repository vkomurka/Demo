using Demo.DAL;
using Demo.WebServer.Model.Entities;

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
            await uow.Repository<Product>().Delete(id);
            await uow.Commit();
        }
    }
}
