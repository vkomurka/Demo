using Demo.Contracts.Dtos;
using Demo.EntityFramework;
using Demo.WebServer.Model.Entities;

namespace Demo.WebServer.Model.Queries
{
    public class WarehousesQuery : QueryBase<WarehouseDto>
    {
        public Guid? Id { get; set; }

        protected override IQueryable<WarehouseDto> GetRecords()
        {
            return
                from warehouse in Context.Set<Warehouse>()
                where Id == null || warehouse.Id == Id
                select new WarehouseDto()
                {
                    Id = warehouse.Id,
                    Name = warehouse.Name,
                };
        }
    }
}
