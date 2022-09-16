using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Demo.Contracts;

namespace Demo.WebAdmin.Controllers;

public class HomeController : Controller
{
    public DemoClient DemoClient { get; }

    public HomeController(DemoClient demoClient)
    {
        DemoClient = demoClient ?? throw new ArgumentNullException(nameof(demoClient));
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }
}