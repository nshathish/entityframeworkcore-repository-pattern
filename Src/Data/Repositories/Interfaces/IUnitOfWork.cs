namespace Data.Repositories.Interfaces;

public interface IUnitOfWork: IDisposable
{
    IEmployeeRepository Employees { get; }
    
    Task<int> CompleteAsync();
    
}