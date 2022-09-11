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
            from category in Context.Set<ProductCategory>()
            where Id == null || category.Id == Id
            select new ProductCategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
            };
    }
}
