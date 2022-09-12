using Demo.Contracts.Dtos;
using Demo.DAL;
using Demo.WebServer.DAL.Queries;

namespace Demo.WebServer.Controllers.Warehouses;

public class GetWarehousesAction : DatabaseAction
{
    public WarehousesQuery WarehousesQuery { get; }

    public GetWarehousesAction(WarehousesQuery warehousesQuery, Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
    {
        WarehousesQuery = warehousesQuery ?? throw new ArgumentNullException(nameof(warehousesQuery));
    }


    public async Task<List<WarehouseDto>> ExecuteAsync(Guid? id)
    {
        using (var uow = UnitOfWorkFactory.Invoke())
        {
            WarehousesQuery.Id = id;
            return await uow.Query(WarehousesQuery);
        }
    }
}