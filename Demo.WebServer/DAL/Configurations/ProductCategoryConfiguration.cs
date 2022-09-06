using Demo.WebServer.DAL.TestData;
using Demo.WebServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.WebServer.DAL.Configurations;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasData(
            new ProductCategory()
            {
                Id = TestDataService.MeatsCategoryId,
                Name = "Meats",
            },
            new ProductCategory()
            {
                Id = TestDataService.FruitsCategoryId,
                Name = "Fruits",
            },
            new ProductCategory()
            {
                Id = TestDataService.ClothesCategoryId,
                Name = "Clothes",
            }
        );
    }
}
