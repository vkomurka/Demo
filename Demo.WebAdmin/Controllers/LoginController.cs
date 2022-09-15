using System.Security.Claims;
using System.Security.Principal;
using Demo.Contracts.Dtos;
using Demo.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebAdmin.Controllers
{
    public class LoginController : Controller
    {
        public DemoClient DemoClient { get; }

        public LoginController(
            DemoClient demoClient)
        {
            DemoClient = demoClient ?? throw new ArgumentNullException(nameof(demoClient));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(LoginDto login)
        {
            if (ModelState.IsValid)
            {
                IActionResult response = Unauthorized();
                var loginResponse = await DemoClient.SecurityClient.LoginAsync(login);
                if (loginResponse != null)
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, "MyUserNameOrID"),
                        new Claim(ClaimTypes.Role, "SomeRoleName"),
                        new Claim(ClaimTypes.Country, loginResponse.Token),
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(identity));
                }
                ModelState.AddModelError("", "Test");
            }

            return View(login);
        }

    }
}
