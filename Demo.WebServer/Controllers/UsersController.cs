using Demo.Contracts.Dtos;
using Demo.WebServer.Controllers.Uoms;
using Demo.WebServer.Controllers.Users;
using Demo.WebServer.Model.Consts;
using Demo.WebServer.Model.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebServer.Controllers
{

    [Route("Api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        public Func<GetUsersAction> GetUsersActionFactory { get; }
        public Func<PostUsersAction> PostUsersActionFactory { get; }
        public Func<PutUsersAction> PutUsersActionFactory { get; }
        public Func<DeleteUsersAction> DeleteUsersActionFactory { get; }

        public UsersController(
            Func<GetUsersAction> getUsersActionFactory,
            Func<PostUsersAction> postUsersActionFactory,
            Func<PutUsersAction> putUsersActionFactory,
            Func<DeleteUsersAction> deleteUsersActionFactory
            )
        {
            GetUsersActionFactory = getUsersActionFactory ?? throw new ArgumentNullException(nameof(getUsersActionFactory));
            PostUsersActionFactory = postUsersActionFactory ?? throw new ArgumentNullException(nameof(postUsersActionFactory));
            PutUsersActionFactory = putUsersActionFactory ?? throw new ArgumentNullException(nameof(putUsersActionFactory));
            DeleteUsersActionFactory = deleteUsersActionFactory ?? throw new ArgumentNullException(nameof(deleteUsersActionFactory));
        }




        [HttpGet]
        //[Roles(ConstsService.AdminRole)]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            return await GetUsersActionFactory.Invoke().ExecuteAsync(null);
        }

        [HttpGet]
        [Route("{id}")]
        [Roles(ConstsService.AdminRole)]
        public async Task<ActionResult<UomDto>> Get([FromRoute] Guid id)
        {
            //var uoms = await GetUsersActionFactory.Invoke().ExecuteAsync(id);
            //return uoms.FirstOrDefault();
            return null;
        }

        [HttpPost]
        [Roles(ConstsService.AdminRole)]
        public async Task Post([FromBody] IEnumerable<UomDto> uoms)
        {
            await PostUsersActionFactory.Invoke().ExecuteAsync(uoms);
        }

        [HttpPut]
        [Roles(ConstsService.AdminRole)]
        public async Task Put([FromBody] IEnumerable<UomDto> uoms)
        {
            await PutUsersActionFactory.Invoke().ExecuteAsync(uoms);
        }

        [HttpDelete]
        [Route("{id}")]
        [Roles(ConstsService.AdminRole)]
        public async Task Delete([FromRoute] Guid id)
        {
            await DeleteUsersActionFactory.Invoke().ExecuteAsync(id);
        }
    }
}
