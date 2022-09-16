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
                        new Claim("Token", loginResponse.Token),
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        //AllowRefresh = <bool>,
                        // Refreshing the authentication session should be allowed.

                        //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        //IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(identity),
                        authProperties);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Test");
            }

            return View(login);
        }

    }
}
