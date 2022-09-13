using Demo.WebServer.Model.RolesService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.WebServer.Model.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole()
            {
                Name = ConstsService.AdminRole,
                NormalizedName = "ADMIN",
            },
            new IdentityRole()
            {
                Name = "User",
                NormalizedName = "USER",
            }
        );
    }
}
