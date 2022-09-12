namespace Demo.DAL;

public interface ICommand
{
    Task<int> Execute(IUnitOfWork unitOfWork);
}