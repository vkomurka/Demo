using Demo.DAL;
using Microsoft.AspNetCore.Identity;

namespace Demo.WebServer.Controllers.Users;

public class DeleteUsersAction : DatabaseAction
{
    public UserManager<IdentityUser> UserManager { get; }

    public DeleteUsersAction(UserManager<IdentityUser> userManager, Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
    {
        UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public async Task ExecuteAsync(Guid id)
    {

    }
}