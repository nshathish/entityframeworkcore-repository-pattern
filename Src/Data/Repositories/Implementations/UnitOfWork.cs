using Data.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Data.Repositories.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly ILogger<IUnitOfWork> _logger;

    public IEmployeeRepository Employees { get; }

    public UnitOfWork(IEmployeeRepository employeeRepository, ILogger<IUnitOfWork> logger, AppDbContext context)
    {
        Employees = employeeRepository;
        _logger = logger;
        _context = context;
    }


    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        _context.Dispose();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
}