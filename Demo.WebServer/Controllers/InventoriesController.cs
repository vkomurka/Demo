using Demo.Contracts.Dtos;
using Demo.WebServer.Controllers.Inventories;
using Demo.WebServer.Model.Roles;
using Demo.WebServer.Model.RolesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebServer.Controllers;

[Route("Api/[controller]")]
[ApiController]
public class InventoriesController : Controller
{
    public InventoriesController(
        Func<GetInventoriesAction> getInventoriesActionFactory
    )
    {
        GetInventoriesActionFactory = getInventoriesActionFactory ?? throw new ArgumentNullException(nameof(getInventoriesActionFactory));
    }

    public Func<GetInventoriesAction> GetInventoriesActionFactory { get; }


    [HttpGet]
    [Roles(ConstsService.UserRole, ConstsService.AdminRole)]
    public async Task<ActionResult<List<InventoryDto>>> Get()
    {
        return await GetInventoriesActionFactory.Invoke().ExecuteAsync(null);
    }

    [HttpGet]
    [Route("{id}")]
    [Roles(ConstsService.UserRole, ConstsService.AdminRole)]
    public async Task<ActionResult<InventoryDto>> Get([FromRoute] Guid id)
    {
        var categories = await GetInventoriesActionFactory.Invoke().ExecuteAsync(id);
        return categories.FirstOrDefault();
    }
}
