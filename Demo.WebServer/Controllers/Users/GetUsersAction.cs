using AutoMapper;
using Demo.Contracts.Dtos;
using Demo.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Demo.WebServer.Controllers.Users;

public class GetUsersAction : DatabaseAction
{
    public UserManager<IdentityUser> UserManager { get; }
    public IMapper Mapper { get; }

    public GetUsersAction(
        UserManager<IdentityUser> userManager,
        IMapper mapper,
        Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
    {
        UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<UserDto>> ExecuteAsync(Guid? id)
    {
        var users = new List<UserDto>();

        var identityUsers = await UserManager.Users.ToListAsync();
        foreach (var identityUser in identityUsers)
        {
            var user = Mapper.Map<UserDto>(identityUser);
            user.Roles = await UserManager.GetRolesAsync(identityUser);
            users.Add(user);
        }
        return users;
    }
}