using Demo.EntityFramework.Interfaces;

namespace Demo.EntityFramework.Actions;

public class DatabaseAction : IAction
{
    public DatabaseAction(Func<IUnitOfWork> unitOfWorkFactory)
    {
        UnitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
    }

    protected Func<IUnitOfWork> UnitOfWorkFactory { get; }
}
