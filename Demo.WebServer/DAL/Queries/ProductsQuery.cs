using Demo.Contracts.Dtos;
using Demo.EntityFramework;
using Demo.WebServer.Entities;

namespace Demo.WebServer.DAL.Queries;

public class ProductsQuery : QueryBase<ProductDto>
{
    public Guid? Id { get; set; }

    protected override IQueryable<ProductDto> GetRecords()
    {
        return
            from product in Context.Set<Product>()
            join uom in Context.Set<Uom>() on product.UomId equals uom.Id into joinedUoms
            from juom in joinedUoms.DefaultIfEmpty()
            join category in Context.Set<ProductCategory>() on product.ProductCategoryId equals category.Id into joinedCategories
            from jcategory in joinedCategories.DefaultIfEmpty()
            where Id == null || product.Id == Id
            select new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                ProductCategoryId = product.ProductCategoryId,
                UomId = product.UomId,
                ProductCategoryName = jcategory != null ? jcategory.Name : "",
                UomCode = juom != null ? juom.Code : "",
            };
    }
}
