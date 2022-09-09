using Demo.Contracts.Dtos;
using Demo.DAL;
using Demo.WebServer.Entities;

namespace Demo.WebServer.DAL.Queries
{
    public class WarehousesQuery : QueryBase<WarehouseDto>
    {
        public Guid? Id { get; set; }

        protected override IQueryable<WarehouseDto> GetRecords()
        {
            return
                from uoms in Context.Set<Warehouse>()
                where Id == null || uoms.Id == Id
                select new WarehouseDto()
                {
                    Id = uoms.Id,
                    Name = uoms.Name,
                };
        }
    }
}
