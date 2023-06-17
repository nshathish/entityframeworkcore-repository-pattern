using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Data.Repositories.Implementations;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context, ILogger<Employee> logger) : base(context, logger)
    {
    }
}