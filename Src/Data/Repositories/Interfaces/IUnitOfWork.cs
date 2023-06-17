namespace Data.Repositories.Interfaces;

public interface IUnitOfWork
{
    IEmployeeRepository EmployeeRepository { get; }
    Task CompleteAsync();
    void Dispose();
}