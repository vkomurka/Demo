using AutoMapper;
using Demo.Contracts.Dtos;
using Demo.DAL;
using Demo.WebServer.Model.Entities;
using Microsoft.AspNetCore.Identity;

namespace Demo.WebServer.Controllers.Users;

public class PutUsersAction : DatabaseAction
{
    public UserManager<IdentityUser> UserManager { get; }

    public PutUsersAction(UserManager<IdentityUser> userManager, Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
    {
        UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public async Task ExecuteAsync(IEnumerable<UomDto> uomDtos)
    {
    }
}