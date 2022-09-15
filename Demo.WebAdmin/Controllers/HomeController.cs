using Demo.WebAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Demo.Contracts.Dtos;
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
        var identity = HttpContext.User.Identity;
        return View();
    }
}