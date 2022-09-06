using AutoMapper;
using Demo.Contracts.Dtos;
using Demo.DAL.Interfaces;
using Demo.WebServer.Entities;

namespace Demo.WebServer.Controllers.ProductCategories;

public class PostProductCategoriesAction : DatabaseAction
{
    public PostProductCategoriesAction(IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
    {
        Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public IMapper Mapper { get; }

    public async Task ExecuteAsync(IEnumerable<ProductCategoryDto> productCategoryDtos)
    {
        using (var uow = UnitOfWorkFactory.Invoke())
        {
            var productCategories = Mapper.Map<List<ProductCategory>>(productCategoryDtos);
            await uow.Repository<ProductCategory>().AddAsync(productCategories);
            await uow.CommitAsync();
        }
    }
}
