namespace Demo.DAL.Interfaces
{
    public interface ICommand
    {
        Task<int> ExecuteAsync(IUnitOfWork unitOfWork);
    }
}
