using Demo.Contracts.Dtos;
using Demo.DAL;
using Demo.WebServer.Entities;

namespace Demo.WebServer.DAL.Queries;

public class ProductCategoriesQuery : QueryBase<ProductCategoryDto>
{
    public Guid? Id { get; set; }

    protected override IQueryable<ProductCategoryDto> GetRecords()
    {
        return
            from categories in Context.Set<ProductCategory>()
            where Id == null || categories.Id == Id
            select new ProductCategoryDto()
            {
                Id = categories.Id,
                Name = categories.Name,
            };
    }
}
