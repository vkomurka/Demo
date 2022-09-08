using Demo.Contracts.Dtos;
using Demo.WebServer.Controllers.ProductCategories;
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
    //[Authorize]
    public async Task<ActionResult<List<ProductCategoryDto>>> Get()
    {
        return await GetProductCategoriesActionFactory.Invoke().ExecuteAsync(null);
    }

    [HttpGet]
    [Route("{id}")]
    //[Authorize]
    public async Task<ActionResult<List<ProductCategoryDto>>> Get([FromRoute] Guid id)
    {
        return await GetProductCategoriesActionFactory.Invoke().ExecuteAsync(id);
    }

    [HttpPost]
    //[Authorize(Roles = TestDataService.AdminRole)]
    public async Task Post([FromBody] IEnumerable<ProductCategoryDto> productCategoryDtos)
    {
        await PostProductCategoriesActionFactory.Invoke().ExecuteAsync(productCategoryDtos);
    }

    [HttpPut]
    //[Authorize(Roles = TestDataService.AdminRole)]
    public async Task Put([FromBody] IEnumerable<ProductCategoryDto> productCategoryDtos)
    {
        await PutProductCategoriesActionFactory.Invoke().ExecuteAsync(productCategoryDtos);
    }

    [HttpDelete]
    [Route("{id}")]
    //[Authorize(Roles = TestDataService.AdminRole)]
    public async Task Delete([FromRoute] Guid id)
    {
        await DeleteProductCategoriesActionFactory.Invoke().ExecuteAsync(id);
    }
}
