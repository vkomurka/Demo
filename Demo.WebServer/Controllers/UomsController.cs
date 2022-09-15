using Demo.Contracts.Dtos;
using Demo.WebServer.Controllers.Uoms;
using Demo.WebServer.Model.Consts;
using Demo.WebServer.Model.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebServer.Controllers;

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
    [Roles(ConstsService.UserRole, ConstsService.AdminRole)]
    public async Task<ActionResult<IEnumerable<UomDto>>> Get()
    {
        return await GetUomsActionFactory.Invoke().ExecuteAsync(null);
    }

    [HttpGet]
    [Route("{id}")]
    [Roles(ConstsService.UserRole, ConstsService.AdminRole)]
    public async Task<ActionResult<UomDto>> Get([FromRoute] Guid id)
    {
        var uoms = await GetUomsActionFactory.Invoke().ExecuteAsync(id);
        return uoms.FirstOrDefault();
    }

    [HttpPost]
    [Roles(ConstsService.AdminRole)]
    public async Task Post([FromBody] IEnumerable<UomDto> uoms)
    {
        await PostUomsActionFactory.Invoke().ExecuteAsync(uoms);
    }

    [HttpPut]
    [Roles(ConstsService.AdminRole)]
    public async Task Put([FromBody] IEnumerable<UomDto> uoms)
    {
        await PutUomsActionFactory.Invoke().ExecuteAsync(uoms);
    }

    [HttpDelete]
    [Route("{id}")]
    [Roles(ConstsService.AdminRole)]
    public async Task Delete([FromRoute] Guid id)
    {
        await DeleteUomsActionFactory.Invoke().ExecuteAsync(id);
    }
}
