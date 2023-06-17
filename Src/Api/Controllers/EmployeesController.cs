using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        var employees = await _unitOfWork.Employees.All();
        return Ok(employees);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetEmployee(Guid id)
    {
        var employee = await _unitOfWork.Employees.GetById(id);
        if (employee == null)
            return NotFound();
        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
    {
        employee.Id = Guid.NewGuid();
        await _unitOfWork.Employees.Add(employee);
        await _unitOfWork.CompleteAsync();
        return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
    }
}