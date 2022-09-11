using Demo.Contracts.Dtos;
using Demo.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebAdmin.Controllers
{
    public class InventoriesController : Controller
    {
        public DemoClient DemoClient { get; }

        public InventoriesController(DemoClient demoClient)
        {
            DemoClient = demoClient ?? throw new ArgumentNullException(nameof(demoClient));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await DemoClient.Inventories.GetAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

    }
}
