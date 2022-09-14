using Demo.WebServer.Model.Consts;
using Demo.WebServer.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.WebServer.Model.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product()
            {
                Id = new Guid("02242EE0-5D67-4669-AF7D-54FA669314CD"),
                Name = "Rump steak",
                UomId = TestDataService.KiloUomId,
                ProductCategoryId = TestDataService.MeatsCategoryId,
            },
            new Product()
            {
                Id = new Guid("90475F49-7F47-4981-BB65-32F87C0D5D72"),
                Name = "T-bone steak",
                UomId = TestDataService.KiloUomId,
                ProductCategoryId = TestDataService.MeatsCategoryId,
            },
            new Product()
            {
                Id = new Guid("6AF118FF-8EF8-440E-A1B3-C640BD0E8437"),
                Name = "Sirloin steak",
                UomId = TestDataService.KiloUomId,
                ProductCategoryId = TestDataService.MeatsCategoryId,
            },
            new Product()
            {
                Id = new Guid("05A8459B-242E-45F5-8380-66979CBD5591"),
                Name = "Apple",
                UomId = TestDataService.KiloUomId,
                ProductCategoryId = TestDataService.FruitsCategoryId,
            },
            new Product()
            {
                Id = new Guid("CE7A5591-EBF1-442C-B54A-8C77B3846B0D"),
                Name = "Pear",
                UomId = TestDataService.KiloUomId,
                ProductCategoryId = TestDataService.FruitsCategoryId,
            },
            new Product()
            {
                Id = new Guid("5F716302-4AAC-448E-9766-FD97EF71648A"),
                Name = "Trousers",
                UomId = TestDataService.PieceUomId,
                ProductCategoryId = TestDataService.ClothesCategoryId,
            },
            new Product()
            {
                Id = new Guid("D557ABEB-DC65-4B19-AD46-9CB7E4A6AF8D"),
                Name = "Shirt",
                UomId = TestDataService.PieceUomId,
                ProductCategoryId = TestDataService.ClothesCategoryId,
            }
        );
    }
}
