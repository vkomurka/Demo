using AutoMapper;
using Demo.Contracts.Dtos;
using Demo.DAL;
using Demo.WebServer.Model.Entities;

namespace Demo.WebServer.Controllers.Uoms;

public class PostUomsAction : DatabaseAction
{
    public PostUomsAction(IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
    {
        Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public IMapper Mapper { get; }

    public async Task ExecuteAsync(IEnumerable<UomDto> uomDtos)
    {
        using (var uow = UnitOfWorkFactory.Invoke())
        {
            var uoms = Mapper.Map<List<Uom>>(uomDtos);
            await uow.Repository<Uom>().Add(uoms);
            await uow.Commit();
        }
    }
}
