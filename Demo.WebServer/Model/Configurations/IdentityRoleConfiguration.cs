using Demo.WebServer.Model.Consts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.WebServer.Model.Configurations;

public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole()
            {
                Id = "8A24F1EC-CEA5-45E6-8660-4ABFF9F4EBC8",
                Name = ConstsService.AdminRole,
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "1",
            },
            new IdentityRole()
            {
                Id = "927B07BE-9F8E-400E-A101-81685CF61BCD",
                Name = ConstsService.UserRole,
                NormalizedName = "USER",
                ConcurrencyStamp = "2",
            }
        );
    }
}
