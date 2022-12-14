using Demo.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebAdmin.Controllers;

public class InventoriesController : Controller
{
    public DemoClient DemoClient { get; }

    public InventoriesController(DemoClient demoClient)
    {
        DemoClient = demoClient ?? throw new ArgumentNullException(nameof(demoClient));
    }

    [HttpGet]
    [Authorize()]
    public async Task<IActionResult> Index()
    {
        var token = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Token");
        if (token != null)
        {
            DemoClient.SetJwtAuthenticator(token.Value);
        }
        return View(await DemoClient.Inventories.GetAsync());
    }

    [HttpGet]
    [Authorize()]
    public IActionResult Create()
    {
        return View();
    }

}