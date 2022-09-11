using Demo.Contracts.Dtos;
using Demo.DAL;
using Demo.WebServer.Entities;

namespace Demo.WebServer.DAL.Queries;

public class InventoriesQuery : QueryBase<InventoryDto>
{
    public Guid? Id { get; set; }

    protected override IQueryable<InventoryDto> GetRecords()
    {
        return
            from inventory in Context.Set<Inventory>()
            join product in Context.Set<Product>() on inventory.ProductId equals product.Id into JoinedProducts
            from jproduct in JoinedProducts.DefaultIfEmpty()
            join category in Context.Set<ProductCategory>() on jproduct.ProductCategoryId equals category.Id into JoinedCategories
            from jcategory in JoinedCategories.DefaultIfEmpty()
            join uom in Context.Set<Uom>() on inventory.UomId equals uom.Id into JoinedUoms
            from juom in JoinedUoms.DefaultIfEmpty()
            where Id == null || inventory.Id == Id
            select new InventoryDto()
            {
                Id = inventory.Id,
                ProductId = inventory.ProductId,
                UomId = inventory.UomId,
                Quantity = inventory.Quantity,
                ProductName = jproduct != null ? jproduct.Name : "",
                ProductCategoryId = jproduct != null ? jproduct.ProductCategoryId : null,
                ProductCategoryName = jcategory!=null? jcategory.Name : "",
                UomCode = juom != null ? juom.Code : "",
            };
    }
}