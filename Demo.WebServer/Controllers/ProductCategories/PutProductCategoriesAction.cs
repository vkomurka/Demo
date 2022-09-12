using AutoMapper;
using Demo.Contracts.Dtos;
using Demo.DAL;
using Demo.EntityFramework.Actions;
using Demo.WebServer.Entities;

namespace Demo.WebServer.Controllers.ProductCategories;

public class PutProductCategoriesAction : DatabaseAction
{
    public PutProductCategoriesAction(IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
    {
        Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public IMapper Mapper { get; }

    public async Task ExecuteAsync(IEnumerable<ProductCategoryDto> productCategoryDtos)
    {
        using (var uow = UnitOfWorkFactory.Invoke())
        {
            var productCategories = Mapper.Map<List<ProductCategory>>(productCategoryDtos);
            uow.Repository<ProductCategory>().Update(productCategories);
            await uow.CommitAsync();
        }
    }
}
