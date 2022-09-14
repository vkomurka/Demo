using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.WebServer.Model.Configurations
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            var userRole = new IdentityUserRole<string>()
            {
                RoleId = "8A24F1EC-CEA5-45E6-8660-4ABFF9F4EBC8",
                UserId = "b74ddd14-6340-4840-95c2-db12554843e5",
            };
            builder.HasData(userRole);
        }
    }
}
