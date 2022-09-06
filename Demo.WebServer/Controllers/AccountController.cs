using Demo.Contracts.Dtos;
using Demo.WebServer.Controllers.Account;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebServer.Controllers;

public class AccountController : ControllerBase
{
    public AccountController(
        Func<RegisterDefaultUsersAction> registerDefaultUsersActionFactory,
        Func<LoginAction> loginActionFactory
        )
    {
        RegisterDefaultUsersActionFactory = registerDefaultUsersActionFactory ?? throw new ArgumentNullException(nameof(registerDefaultUsersActionFactory));
        LoginActionFactory = loginActionFactory ?? throw new ArgumentNullException(nameof(loginActionFactory));
    }

    public Func<RegisterDefaultUsersAction> RegisterDefaultUsersActionFactory { get; }
    public Func<LoginAction> LoginActionFactory { get; }

    [HttpPost]
    [Route("RegisterDefaultUsers")]
    public async Task RegisterDefaultUsers()
    {
        await RegisterDefaultUsersActionFactory.Invoke().ExeccuteAsync();
    }

    [HttpPost]
    [Route("Login")]
    public async Task<ActionResult> Login([FromBody] UserDto userDto)
    {
        var response = await LoginActionFactory.Invoke().ExecuteAsync(userDto);
        if (response == null)
        {
            return Unauthorized();
        }
        return Ok(response);
    }
}
