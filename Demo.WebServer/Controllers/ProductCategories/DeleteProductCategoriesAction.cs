using Demo.DAL;
using Demo.WebServer.Entities;

namespace Demo.WebServer.Controllers.ProductCategories;

public class DeleteProductCategoriesAction : DatabaseAction
{
    public DeleteProductCategoriesAction(Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
    {
    }

    public async Task ExecuteAsync(Guid id)
    {
        using (var uow = UnitOfWorkFactory.Invoke())
        {
            await uow.Repository<ProductCategory>().Delete(id);
            await uow.Commit();
        }
    }
}
