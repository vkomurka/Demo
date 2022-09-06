using Demo.Contracts.Dtos;
using Demo.DAL;
using Demo.WebServer.Entities;

namespace Demo.WebServer.DAL.Queries;

public class UomsQuery : QueryBase<UomDto>
{
    public Guid? Id { get; set; }

    protected override IQueryable<UomDto> GetRecords()
    {
        return
            from uoms in Context.Set<Uom>()
            where Id == null || uoms.Id == Id
            select new UomDto()
            {
                Id = uoms.Id,
                Code = uoms.Code,
            };
    }
}
