using Demo.Contracts.Dtos;
using Demo.WebServer.Controllers.ProductCategories;
using Demo.WebServer.Model.Consts;
using Demo.WebServer.Model.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebServer.Controllers;

[Route("Api/[controller]")]
[ApiController]
public class ProductCategoriesController : Controller
{
    public ProductCategoriesController(
        Func<GetProductCategoriesAction> getProductCategoriesActionFactory,
        Func<PostProductCategoriesAction> postProductCategoriesActionFactory,
        Func<PutProductCategoriesAction> putProductCategoriesActionFactory,
        Func<DeleteProductCategoriesAction> deleteProductCategoriesActionFactory
        )
    {
        GetProductCategoriesActionFactory = getProductCategoriesActionFactory ?? throw new ArgumentNullException(nameof(getProductCategoriesActionFactory));
        PostProductCategoriesActionFactory = postProductCategoriesActionFactory ?? throw new ArgumentNullException(nameof(postProductCategoriesActionFactory));
        PutProductCategoriesActionFactory = putProductCategoriesActionFactory ?? throw new ArgumentNullException(nameof(putProductCategoriesActionFactory));
        DeleteProductCategoriesActionFactory = deleteProductCategoriesActionFactory ?? throw new ArgumentNullException(nameof(deleteProductCategoriesActionFactory));
    }

    public Func<GetProductCategoriesAction> GetProductCategoriesActionFactory { get; }
    public Func<PostProductCategoriesAction> PostProductCategoriesActionFactory { get; }
    public Func<PutProductCategoriesAction> PutProductCategoriesActionFactory { get; }
    public Func<DeleteProductCategoriesAction> DeleteProductCategoriesActionFactory { get; }

    [HttpGet]
    [Roles(ConstsService.AdminRole)]
    [Authorize()]
    public async Task<ActionResult<List<ProductCategoryDto>>> Get()
    {
        return await GetProductCategoriesActionFactory.Invoke().ExecuteAsync(null);
    }

    [HttpGet]
    [Route("{id}")]
    [Roles(ConstsService.UserRole, ConstsService.AdminRole)]
    public async Task<ActionResult<ProductCategoryDto>> Get([FromRoute] Guid id)
    {
        var categories = await GetProductCategoriesActionFactory.Invoke().ExecuteAsync(id);
        return categories.FirstOrDefault();
    }

    [HttpPost]
    [Roles(ConstsService.AdminRole)]
    public async Task Post([FromBody] IEnumerable<ProductCategoryDto> productCategoryDtos)
    {
        await PostProductCategoriesActionFactory.Invoke().ExecuteAsync(productCategoryDtos);
    }

    [HttpPut]
    [Roles(ConstsService.AdminRole)]
    public async Task Put([FromBody] IEnumerable<ProductCategoryDto> productCategoryDtos)
    {
        await PutProductCategoriesActionFactory.Invoke().ExecuteAsync(productCategoryDtos);
    }

    [HttpDelete]
    [Route("{id}")]
    [Roles(ConstsService.AdminRole)]
    public async Task Delete([FromRoute] Guid id)
    {
        await DeleteProductCategoriesActionFactory.Invoke().ExecuteAsync(id);
    }
}
