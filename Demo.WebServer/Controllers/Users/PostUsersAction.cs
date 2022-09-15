using Demo.Contracts.Dtos;
using Demo.DAL;
using Microsoft.AspNetCore.Identity;

namespace Demo.WebServer.Controllers.Users;

public class PostUsersAction : DatabaseAction
{
    public UserManager<IdentityUser> UserManager { get; }

    public PostUsersAction(UserManager<IdentityUser> userManager, Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
    {
        UserManager = userManager;
    }

    public async Task ExecuteAsync(IEnumerable<UomDto> uomDtos)
    {
    }
}