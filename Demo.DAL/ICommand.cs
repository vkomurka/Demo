namespace Demo.DAL;

public interface ICommand
{
    Task<int> ExecuteAsync(IUnitOfWork unitOfWork);
}