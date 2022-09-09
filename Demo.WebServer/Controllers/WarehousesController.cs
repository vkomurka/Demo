using Demo.Contracts.Dtos;
using Demo.WebServer.Controllers.Warehouses;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebServer.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class WarehousesController : Controller
    {
        public Func<GetWarehousesAction> GetWarehousesActionFactory { get; }
        public Func<PostWarehousesAction> PostWarehousesActionFactory { get; }
        public Func<PutWarehousesAction> PutWarehousesActionFactory { get; }
        public Func<DeleteWarehousesAction> DeleteWarehousesActionFactory { get; }

        public WarehousesController(
            Func<GetWarehousesAction> getWarehousesActionFactory,
            Func<PostWarehousesAction> postWarehousesActionFactory,
            Func<PutWarehousesAction> putWarehousesActionFactory,
            Func<DeleteWarehousesAction> deleteWarehousesActionFactory
            )
        {
            GetWarehousesActionFactory = getWarehousesActionFactory ?? throw new ArgumentNullException(nameof(getWarehousesActionFactory));
            PostWarehousesActionFactory = postWarehousesActionFactory ?? throw new ArgumentNullException(nameof(postWarehousesActionFactory));
            PutWarehousesActionFactory = putWarehousesActionFactory ?? throw new ArgumentNullException(nameof(putWarehousesActionFactory));
            DeleteWarehousesActionFactory = deleteWarehousesActionFactory ?? throw new ArgumentNullException(nameof(deleteWarehousesActionFactory));
        }

        [HttpGet]
        //[Authorize()]
        public async Task<ActionResult<List<WarehouseDto>>> Get()
        {
            return await GetWarehousesActionFactory.Invoke().ExecuteAsync(null);
        }

        [HttpGet]
        [Route("{id}")]
        //[Authorize()]
        public async Task<ActionResult<WarehouseDto>> Get([FromRoute] Guid id)
        {
            var uoms = await GetWarehousesActionFactory.Invoke().ExecuteAsync(id);
            return uoms.FirstOrDefault();
        }

        [HttpPost]
        //[Authorize(Roles = TestDataService.AdminRole)]
        public async Task Post([FromBody] IEnumerable<WarehouseDto> warehouses)
        {
            await PostWarehousesActionFactory.Invoke().ExecuteAsync(warehouses);
        }

        [HttpPut]
        //[Authorize(Roles = TestDataService.AdminRole)]
        public async Task Put([FromBody] IEnumerable<WarehouseDto> warehouses)
        {
            await PutWarehousesActionFactory.Invoke().ExecuteAsync(warehouses);
        }

        [HttpDelete]
        [Route("{id}")]
        //[Authorize(Roles = TestDataService.AdminRole)]
        public async Task Delete([FromRoute] Guid id)
        {
            await DeleteWarehousesActionFactory.Invoke().ExecuteAsync(id);
        }
    }
}
