using Demo.DAL.Interfaces;
using Demo.WebApi;
using Demo.WebServer.Entities;

namespace Demo.WebServer.Areas.Api.Controllers.Products;

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
