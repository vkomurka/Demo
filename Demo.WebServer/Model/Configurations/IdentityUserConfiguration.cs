using Demo.WebServer.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Demo.WebServer.Model.Configurations
{
    public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var user = new IdentityUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Admin",
                Email = "",
                LockoutEnabled = false,
                PhoneNumber = ""
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();
            passwordHasher.HashPassword(user, "Admin*123");

            builder.HasData(user);
        }
    }
}
