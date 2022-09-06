using Demo.Contracts.Dtos;
using Demo.DAL;
using Demo.WebServer.Entities;

namespace Demo.WebServer.DAL.Queries;

public class ProductsQuery : QueryBase<ProductDto>
{
    public Guid? Id { get; set; }

    protected override IQueryable<ProductDto> GetRecords()
    {
        return
            from products in Context.Set<Product>()
            join uoms in Context.Set<Uom>() on products.UomId equals uoms.Id into joinedUoms
            from juoms in joinedUoms.DefaultIfEmpty()
            join categories in Context.Set<ProductCategory>() on products.ProductCategoryId equals categories.Id into joinedCategories
            from jcategories in joinedCategories.DefaultIfEmpty()
            where Id == null || products.Id == Id
            select new ProductDto()
            {
                Id = products.Id,
                Name = products.Name,
                ProductCategoryId = products.ProductCategoryId,
                UomId = products.UomId,
                ProductCategoryName = jcategories != null ? jcategories.Name : "",
                UomCode = juoms != null ? juoms.Code : "",
            };
    }
}
