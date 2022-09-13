using Demo.Contracts.Dtos;
using Demo.DAL;
using Demo.WebServer.Model.Queries;

namespace Demo.WebServer.Controllers.Inventories;

public class GetInventoriesAction : DatabaseAction
{
    public InventoriesQuery InventoriesQuery { get; }

    public GetInventoriesAction(InventoriesQuery inventoriesQuery, Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
    {
        InventoriesQuery = inventoriesQuery ?? throw new ArgumentNullException(nameof(inventoriesQuery));
    }


    public async Task<List<InventoryDto>> ExecuteAsync(Guid? id)
    {
        using (var uow = UnitOfWorkFactory.Invoke())
        {
            InventoriesQuery.Id = id;
            return await uow.Query(InventoriesQuery);
        }
    }
}