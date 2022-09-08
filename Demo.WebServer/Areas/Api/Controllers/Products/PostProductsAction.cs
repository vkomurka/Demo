using AutoMapper;
using Demo.Contracts.Dtos;
using Demo.DAL.Interfaces;
using Demo.WebApi;
using Demo.WebServer.Entities;

namespace Demo.WebServer.Areas.Api.Controllers.Products;

public class PostProductsAction : DatabaseAction
{
    public PostProductsAction(IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
    {
        Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public IMapper Mapper { get; }

    public async Task ExecuteAsync(IEnumerable<ProductDto> productDtos)
    {
        using (var uow = UnitOfWorkFactory.Invoke())
        {
            var products = Mapper.Map<List<Product>>(productDtos);
            await uow.Repository<Product>().AddAsync(products);
            await uow.CommitAsync();
        }
    }
}
