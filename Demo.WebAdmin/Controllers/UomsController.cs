using Demo.Contracts;
using Demo.Contracts.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebAdmin.Controllers;

public class UomsController : Controller
{
    public DemoClient DemoClient { get; }

    public UomsController(DemoClient demoClient)
    {
        DemoClient = demoClient ?? throw new ArgumentNullException(nameof(demoClient));
    }

    [HttpGet]
    [Authorize()]
    public async Task<IActionResult> Index()
    {
        return View(await DemoClient.Uoms.GetAsync());
    }

    [HttpGet]
    [Authorize()]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize()]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(UomDto uom)
    {
        if (ModelState.IsValid)
        {
            uom.Id = Guid.NewGuid();
            await DemoClient.Uoms.PostAsync(new List<UomDto> { uom });
            TempData["message"] = "Uom created successfully.";
            return RedirectToAction("Index");
        }
        return View(uom);
    }

    [HttpGet]
    [Authorize()]
    public async Task<IActionResult> Edit(Guid? id)
    {
        if ((id == null) || (id == Guid.Empty))
        {
            return NotFound();
        }
        var uom = await DemoClient.Uoms.GetAsync((Guid)id);

        if (uom == null)
        {
            return NotFound();
        }
        return View(uom);
    }

    [HttpPost]
    [Authorize()]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UomDto uom)
    {
        if (ModelState.IsValid)
        {
            await DemoClient.Uoms.PutAsync(new List<UomDto> { uom });
            TempData["message"] = "Uom updated successfully.";
            return RedirectToAction("Index");
        }
        return View(uom);
    }

    [HttpGet]
    [Authorize()]
    public async Task<IActionResult> Delete(Guid? id)
    {
        if ((id == null) || (id == Guid.Empty))
        {
            return NotFound();
        }
        var uom = await DemoClient.Uoms.GetAsync((Guid)id);

        if (uom == null)
        {
            return NotFound();
        }
        return View(uom);
    }

    [HttpPost]
    [Authorize()]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(UomDto uom)
    {
        await DemoClient.Uoms.DeleteAsync(uom.Id);
        TempData["message"] = "Uom deleted successfully.";
        return RedirectToAction("Index");
    }
}