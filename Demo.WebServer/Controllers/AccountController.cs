using Demo.Contracts.Dtos;
using Demo.WebServer.Controllers.Account;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebServer.Controllers;

[Route("Api/[controller]")]
[ApiController]
public class AccountController : Controller
{
    public AccountController(
        Func<LoginAction> loginActionFactory
        )
    {
        LoginActionFactory = loginActionFactory ?? throw new ArgumentNullException(nameof(loginActionFactory));
    }

    public Func<LoginAction> LoginActionFactory { get; }

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
