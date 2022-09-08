using Demo.Contracts.Dtos;
using Demo.WebServer.Areas.Api.Controllers.Uoms;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebServer.Areas.Api.Controllers;

[Route("Api/[controller]")]
[ApiController]
public class UomsController : Controller 
{
    public UomsController(
        Func<GetUomsAction> getUomsActionFactory,
        Func<PostUomsAction> postUomsActionFactory,
        Func<PutUomsAction> putUomsActionFactory,
        Func<DeleteUomsAction> deleteUomActionFactory
        )
    {
        DeleteUomsActionFactory = deleteUomActionFactory ?? throw new ArgumentNullException(nameof(deleteUomActionFactory));
        GetUomsActionFactory = getUomsActionFactory ?? throw new ArgumentNullException(nameof(getUomsActionFactory));
        PostUomsActionFactory = postUomsActionFactory ?? throw new ArgumentNullException(nameof(postUomsActionFactory));
        PutUomsActionFactory = putUomsActionFactory ?? throw new ArgumentNullException(nameof(putUomsActionFactory));
    }

    public Func<DeleteUomsAction> DeleteUomsActionFactory { get; }
    public Func<GetUomsAction> GetUomsActionFactory { get; }
    public Func<PostUomsAction> PostUomsActionFactory { get; }
    public Func<PutUomsAction> PutUomsActionFactory { get; }


    [HttpGet]
    //[Authorize()]
    public async Task<ActionResult<List<UomDto>>> Get()
    {
        return await GetUomsActionFactory.Invoke().ExecuteAsync(null);
    }

    [HttpGet]
    [Route("{id}")]
    //[Authorize()]
    public async Task<ActionResult<List<UomDto>>> Get([FromRoute] Guid id)
    {
        return await GetUomsActionFactory.Invoke().ExecuteAsync(id);
    }

    [HttpPost]
    //[Authorize(Roles = TestDataService.AdminRole)]
    public async Task Post([FromBody] IEnumerable<UomDto> uoms)
    {
        await PostUomsActionFactory.Invoke().ExecuteAsync(uoms);
    }

    [HttpPut]
    //[Authorize(Roles = TestDataService.AdminRole)]
    public async Task Put([FromBody] IEnumerable<UomDto> uoms)
    {
        await PutUomsActionFactory.Invoke().ExecuteAsync(uoms);
    }

    [HttpDelete]
    [Route("{id}")]
    //[Authorize(Roles = TestDataService.AdminRole)]
    public async Task Delete([FromRoute] Guid id)
    {
        await DeleteUomsActionFactory.Invoke().ExecuteAsync(id);
    }
}
