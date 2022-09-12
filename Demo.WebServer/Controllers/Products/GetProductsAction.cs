using Demo.Contracts.Dtos;
using Demo.DAL;
using Demo.WebServer.DAL.Queries;

namespace Demo.WebServer.Controllers.Products;

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
            return await uow.Query(ProductsQuery);
        }
    }
}
