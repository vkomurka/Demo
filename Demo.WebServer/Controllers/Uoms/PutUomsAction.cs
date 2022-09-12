using AutoMapper;
using Demo.Contracts.Dtos;
using Demo.DAL;
using Demo.EntityFramework.Actions;
using Demo.WebServer.Entities;

namespace Demo.WebServer.Controllers.Uoms;

public class PutUomsAction : DatabaseAction
{
    public PutUomsAction(IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
    {
        Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public IMapper Mapper { get; }

    public async Task ExecuteAsync(IEnumerable<UomDto> uomDtos)
    {
        using (var uow = UnitOfWorkFactory.Invoke())
        {
            var uoms = Mapper.Map<List<Uom>>(uomDtos);
            uow.Repository<Uom>().Update(uoms);
            await uow.Commit();
        }
    }
}
