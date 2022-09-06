using Demo.Contracts.Dtos;
using Demo.DAL.Interfaces;
using Demo.WebServer.DAL.Queries;

namespace Demo.WebServer.Controllers.Uoms;

public class GetUomsAction : DatabaseAction
{
    public GetUomsAction(UomsQuery uomsQuery, Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
    {
        UomsQuery = uomsQuery ?? throw new ArgumentNullException(nameof(uomsQuery));
    }

    public UomsQuery UomsQuery { get; }

    public async Task<List<UomDto>> ExecuteAsync(Guid? id)
    {
        using (var uow = UnitOfWorkFactory.Invoke())
        {
            UomsQuery.Id = id;
            return await uow.QueryAsync(UomsQuery);
        }
    }
}
