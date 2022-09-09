using Demo.Contracts.Dtos;
using Demo.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebAdmin.Controllers;

public class WarehousesController : Controller
{
    public DemoClient DemoClient { get; }

    public WarehousesController(DemoClient demoClient)
    {
        DemoClient = demoClient ?? throw new ArgumentNullException(nameof(demoClient));
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await DemoClient.Warehouses.GetAsync());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(WarehouseDto warehouse)
    {
        if (ModelState.IsValid)
        {
            warehouse.Id = Guid.NewGuid();
            await DemoClient.Warehouses.PostAsync(new List<WarehouseDto> { warehouse });
            TempData["message"] = "Warehouse created successfully.";
            return RedirectToAction("Index");
        }
        return View(warehouse);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid? id)
    {
        if ((id == null) || (id == Guid.Empty))
        {
            return NotFound();
        }
        var uom = await DemoClient.Warehouses.GetAsync((Guid)id);

        if (uom == null)
        {
            return NotFound();
        }
        return View(uom);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(WarehouseDto warehouse)
    {
        if (ModelState.IsValid)
        {
            await DemoClient.Warehouses.PutAsync(new List<WarehouseDto> { warehouse });
            TempData["message"] = "Warehouse updated successfully.";
            return RedirectToAction("Index");
        }
        return View(warehouse);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid? id)
    {
        if ((id == null) || (id == Guid.Empty))
        {
            return NotFound();
        }
        var uom = await DemoClient.Warehouses.GetAsync((Guid)id);

        if (uom == null)
        {
            return NotFound();
        }
        return View(uom);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(WarehouseDto warehouse)
    {
        await DemoClient.Warehouses.DeleteAsync(warehouse.Id);
        TempData["message"] = "Warehouse deleted successfully.";
        return RedirectToAction("Index");
    }
}