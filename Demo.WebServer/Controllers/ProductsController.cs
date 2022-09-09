using Demo.Contracts.Dtos;
using Demo.WebServer.Controllers.Products;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebServer.Controllers;

[Route("Api/[controller]")]
[ApiController]
public class ProductsController : Controller
{
    public ProductsController(
        Func<GetProductsAction> getProductsActionFactory,
        Func<PostProductsAction> postProductsActionFactory,
        Func<PutProductsAction> putProductsActionFactory,
        Func<DeleteProductsAction> deleteProductsActionFactory
        )
    {
        GetProductsActionFactory = getProductsActionFactory ?? throw new ArgumentNullException(nameof(getProductsActionFactory));
        PostProductsActionFactory = postProductsActionFactory ?? throw new ArgumentNullException(nameof(postProductsActionFactory));
        PutProductsActionFactory = putProductsActionFactory ?? throw new ArgumentNullException(nameof(putProductsActionFactory));
        DeleteProductsActionFactory = deleteProductsActionFactory ?? throw new ArgumentNullException(nameof(deleteProductsActionFactory));
    }

    public Func<GetProductsAction> GetProductsActionFactory { get; }
    public Func<PostProductsAction> PostProductsActionFactory { get; }
    public Func<PutProductsAction> PutProductsActionFactory { get; }
    public Func<DeleteProductsAction> DeleteProductsActionFactory { get; }


    [HttpGet]
    //[Authorize()]
    public async Task<ActionResult<List<ProductDto>>> Get()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await GetProductsActionFactory.Invoke().ExecuteAsync(null);
    }

    [HttpGet]
    [Route("{id}")]
    //[Authorize()]
    public async Task<ActionResult<ProductDto>> Get([FromRoute] Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var products = await GetProductsActionFactory.Invoke().ExecuteAsync(id);
        return products.FirstOrDefault();
    }

    [HttpPost]
    //[Authorize(Roles = TestDataService.AdminRole)]
    public async Task Post([FromBody] IEnumerable<ProductDto> productDtos)
    {
        await PostProductsActionFactory.Invoke().ExecuteAsync(productDtos);
    }

    [HttpPut]
    //[Authorize(Roles = TestDataService.AdminRole)]
    public async Task Put([FromBody] IEnumerable<ProductDto> productDtos)
    {
        await PutProductsActionFactory.Invoke().ExecuteAsync(productDtos);
    }

    [HttpDelete]
    [Route("{id}")]
    //[Authorize(Roles = TestDataService.AdminRole)]
    public async Task Delete([FromRoute] Guid id)
    {
        await DeleteProductsActionFactory.Invoke().ExecuteAsync(id);
    }
}
