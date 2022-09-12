using AutoMapper;
using Demo.Contracts.Dtos;
using Demo.DAL;
using Demo.EntityFramework.Actions;
using Demo.WebServer.Entities;

namespace Demo.WebServer.Controllers.Products;

public class PutProductsAction : DatabaseAction
{
    public PutProductsAction(IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
    {
        Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public IMapper Mapper { get; }

    public async Task ExecuteAsync(IEnumerable<ProductDto> productDtos)
    {
        using (var uow = UnitOfWorkFactory.Invoke())
        {
            var products = Mapper.Map<List<Product>>(productDtos);
            uow.Repository<Product>().Update(products);
            await uow.Commit();
        }
    }
}
