using AutoMapper;
using Demo.Contracts.Dtos;
using Demo.DAL.Actions;
using Demo.DAL.Interfaces;
using Demo.WebServer.Entities;

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
            await uow.Repository<Uom>().AddAsync(uoms);
            await uow.CommitAsync();
        }
    }
}
