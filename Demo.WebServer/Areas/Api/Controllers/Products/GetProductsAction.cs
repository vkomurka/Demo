using Demo.Contracts.Dtos;
using Demo.DAL.Interfaces;
using Demo.WebApi;
using Demo.WebServer.DAL.Queries;

namespace Demo.WebServer.Areas.Api.Controllers.Products;

public class GetProductsAction : DatabaseAction
{
    public GetProductsAction(ProductsQuery productsQuery, Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
    {
        ProductsQuery = productsQuery ?? throw new ArgumentNullException(nameof(productsQuery));
    }

    public ProductsQuery ProductsQuery { get; }

    public async Task<List<ProductDto>> ExecuteAsync(Guid? id)
    {
        using (var uow = UnitOfWorkFactory.Invoke())
        {
            ProductsQuery.Id = id;
            return await uow.QueryAsync(ProductsQuery);
        }
    }
}
