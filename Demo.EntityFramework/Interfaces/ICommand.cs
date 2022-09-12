namespace Demo.EntityFramework.Interfaces
{
    public interface ICommand
    {
        Task<int> ExecuteAsync(IUnitOfWork unitOfWork);
    }
}
