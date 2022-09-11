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
            from uom in Context.Set<Uom>()
            where Id == null || uom.Id == Id
            select new UomDto()
            {
                Id = uom.Id,
                Code = uom.Code,
            };
    }
}
