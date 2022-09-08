using Demo.Contracts.Dtos;
using Demo.DAL.Actions;
using Demo.DAL.Interfaces;
using Demo.WebServer.DAL.Queries;

namespace Demo.WebServer.Controllers.ProductCategories;

public class GetProductCategoriesAction : DatabaseAction
{
    public GetProductCategoriesAction(ProductCategoriesQuery productCategoriesQuery, Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
    {
        ProductCategoriesQuery = productCategoriesQuery ?? throw new ArgumentNullException(nameof(productCategoriesQuery));
    }

    public ProductCategoriesQuery ProductCategoriesQuery { get; }

    public async Task<List<ProductCategoryDto>> ExecuteAsync(Guid? id)
    {
        using (var uow = UnitOfWorkFactory.Invoke())
        {
            ProductCategoriesQuery.Id = id;
            return await uow.QueryAsync(ProductCategoriesQuery);
        }
    }
}
