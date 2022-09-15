using Demo.Contracts.Dtos;
using Demo.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Demo.WebAdmin.Controllers;

public class ProductsController : Controller
{
    public DemoClient DemoClient { get; }

    public ProductsController(DemoClient demoClient)
    {
        DemoClient = demoClient ?? throw new ArgumentNullException(nameof(demoClient));
    }

    [HttpGet]
    [Authorize()]
    public async Task<IActionResult> Index()
    {
        return View(await DemoClient.Products.GetAsync());
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
    public async Task<IActionResult> Create(ProductDto product)
    {
        if (ModelState.IsValid)
        {
            product.Id = Guid.NewGuid();
            await DemoClient.Products.PostAsync(new List<ProductDto> { product });
            TempData["message"] = "Product created successfully.";
            return RedirectToAction("Index");
        }
        return View(product);
    }

    [HttpGet]
    [Authorize()]
    public async Task<IActionResult> Edit(Guid? id)
    {
        if ((id == null) || (id == Guid.Empty))
        {
            return NotFound();
        }
        var uom = await DemoClient.Products.GetAsync((Guid)id);

        if (uom == null)
        {
            return NotFound();
        }
        return View(uom);
    }

    [HttpPost]
    [Authorize()]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProductDto product)
    {
        if (ModelState.IsValid)
        {
            await DemoClient.Products.PutAsync(new List<ProductDto> { product });
            TempData["message"] = "Product updated successfully.";
            return RedirectToAction("Index");
        }
        return View(product);
    }

    [HttpGet]
    [Authorize()]
    public async Task<IActionResult> Delete(Guid? id)
    {
        if ((id == null) || (id == Guid.Empty))
        {
            return NotFound();
        }
        var uom = await DemoClient.Products.GetAsync((Guid)id);

        if (uom == null)
        {
            return NotFound();
        }
        return View(uom);
    }

    [HttpPost]
    [Authorize()]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(ProductDto product)
    {
        await DemoClient.Products.DeleteAsync(product.Id);
        TempData["message"] = "Product deleted successfully.";
        return RedirectToAction("Index");
    }
}