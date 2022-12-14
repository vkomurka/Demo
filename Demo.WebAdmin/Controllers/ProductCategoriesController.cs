using Demo.Contracts.Dtos;
using Demo.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Demo.WebAdmin.Controllers;

public class ProductCategoriesController : Controller
{
    public DemoClient DemoClient { get; }

    public ProductCategoriesController(DemoClient demoClient)
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
        return View(await DemoClient.ProductCategories.GetAsync());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize()]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductCategoryDto category)
    {
        if (ModelState.IsValid)
        {
            category.Id = Guid.NewGuid();
            await DemoClient.ProductCategories.PostAsync(new List<ProductCategoryDto> { category });
            TempData["message"] = "Product Category created successfully.";
            return RedirectToAction("Index");
        }
        return View(category);
    }

    [HttpGet]
    [Authorize()]
    public async Task<IActionResult> Edit(Guid? id)
    {
        if ((id == null) || (id == Guid.Empty))
        {
            return NotFound();
        }
        var category = await DemoClient.ProductCategories.GetAsync((Guid)id);

        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    [HttpPost]
    [Authorize()]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProductCategoryDto category)
    {
        if (ModelState.IsValid)
        {
            await DemoClient.ProductCategories.PutAsync(new List<ProductCategoryDto> { category });
            TempData["message"] = "Product Category updated successfully.";
            return RedirectToAction("Index");
        }
        return View(category);
    }

    [HttpGet]
    [Authorize()]
    public async Task<IActionResult> Delete(Guid? id)
    {
        if ((id == null) || (id == Guid.Empty))
        {
            return NotFound();
        }
        var category = await DemoClient.ProductCategories.GetAsync((Guid)id);

        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    [HttpPost]
    [Authorize()]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(ProductCategoryDto category)
    {
        await DemoClient.ProductCategories.DeleteAsync(category.Id);
        TempData["message"] = "Product Category deleted successfully.";
        return RedirectToAction("Index");
    }
}