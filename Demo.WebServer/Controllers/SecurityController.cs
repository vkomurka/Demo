using Demo.Contracts.Dtos;
using Demo.WebServer.Controllers.Account;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebServer.Controllers;

[Route("Api/[controller]")]
[ApiController]
public class SecurityController : Controller
{
    public SecurityController(
        Func<LoginAction> loginActionFactory
        )
    {
        LoginActionFactory = loginActionFactory ?? throw new ArgumentNullException(nameof(loginActionFactory));
    }

    public Func<LoginAction> LoginActionFactory { get; }

    [HttpPost]
    [Route("Login")]
    public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginDto userDto)
    {
        var response = await LoginActionFactory.Invoke().ExecuteAsync(userDto);
        if (response == null)
        {
            return Unauthorized();
        }
        return Ok(response);
    }
}
