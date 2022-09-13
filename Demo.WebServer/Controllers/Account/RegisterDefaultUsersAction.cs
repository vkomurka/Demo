using Demo.DAL;
using Demo.WebServer.Model.TestData;
using Microsoft.AspNetCore.Identity;

namespace Demo.WebServer.Controllers.Account;

public class RegisterDefaultUsersAction : IAction
{
    public RegisterDefaultUsersAction(UserManager<IdentityUser> userManager)
    {
        UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public UserManager<IdentityUser> UserManager { get; }

    public async Task ExeccuteAsync()
    {
        var adminUser = new IdentityUser()
        {
            Email = "admin@test.com",
            UserName = "admin@test.com"
        };

        var result = await UserManager.CreateAsync(adminUser, "Password-123");
        if (result.Succeeded)
        {
            await UserManager.AddToRoleAsync(adminUser, TestDataService.AdminRole);
        }

        var user = new IdentityUser()
        {
            Email = "user@test.com",
            UserName = "user@test.com"
        };

        await UserManager.CreateAsync(user, "Password-456");
        await UserManager.AddToRoleAsync(user, TestDataService.UserRole);
    }
}
