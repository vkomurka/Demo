using Demo.DAL.Interfaces;
using Demo.WebApi;

namespace Demo.WebServer.Controllers;

public class DatabaseAction : IAction
{
    public DatabaseAction(Func<IUnitOfWork> unitOfWorkFactory)
    {
        UnitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
    }

    protected Func<IUnitOfWork> UnitOfWorkFactory { get; }
}
