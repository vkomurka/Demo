using Demo.WebServer.Model.Consts;
using Demo.WebServer.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.WebServer.Model.Configurations;

public class UomConfiguration : IEntityTypeConfiguration<Uom>
{
    public void Configure(EntityTypeBuilder<Uom> builder)
    {
        builder.HasData(
            new Uom()
            {
                Id = TestDataService.KiloUomId,
                Code = "Kg"
            },
            new Uom()
            {
                Id = TestDataService.PieceUomId,
                Code = "Pcs"
            }
        );
    }
}
