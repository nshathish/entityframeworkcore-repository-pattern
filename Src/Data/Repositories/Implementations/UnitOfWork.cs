using Data.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Data.Repositories.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly ILogger<IUnitOfWork> _logger;

    public IEmployeeRepository EmployeeRepository { get; }

    public UnitOfWork(IEmployeeRepository employeeRepository, ILogger<IUnitOfWork> logger, AppDbContext context)
    {
        EmployeeRepository = employeeRepository;
        _logger = logger;
        _context = context;
    }


    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}