using Microsoft.AspNetCore.Mvc;
using PayrollSystem.Services.Interfaces;
using PayrollSystem.DTOs;
using PayrollSystem.Helpers;

[ApiController]
[Route("api/[controller]")]

public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _employeeService.GetAllAsync();
        return Ok(ApiResponse.Ok(employees));
    }

    [HttpGet("{registrationnumber}")]
    public async Task<IActionResult> GetById(int registrationnumber)
    {
        var employee = await _employeeService.GetByIdAsync(registrationnumber);
        if (employee == null) 
            return NotFound(ApiResponse.NotFound("Δεν υπάρχει υπάλληλος με αυτό το ΑΜ!"));
        return Ok(ApiResponse.Ok(employee));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeDto dto)
    {
        var employee = await _employeeService.CreateAsync(dto);
        if (employee == null) 
            return NotFound(ApiResponse.NotFound("Κάποιο απο τα στοιχεία που βάλατε είναι λάθος!"));
        return Ok(ApiResponse.Ok(employee));    
    }

    [HttpPut("{registrationnumber}")]
    public async Task<IActionResult> Put(int registrationnumber, UpdateEmployeeDto dto)
    {
        var employee = await _employeeService.PutAsync(registrationnumber, dto);
        if (!employee) 
            return NotFound(ApiResponse.NotFound("Δεν υπάρχει υπάλληλος με αυτό το ΑΜ!"));
        return Ok(ApiResponse.Ok("Ενημερώθηκε!"));
    }

    [HttpDelete("{registrationnumber}")]
    public async Task<IActionResult> Delete(int registrationnumber)
    {
        var employee = await _employeeService.DeleteAsync(registrationnumber);
        if (!employee)
            return NotFound(ApiResponse.NotFound("Δεν υπάρχει υπάλληλος με αυτό το ΑΜ!"));
        return Ok(ApiResponse.Ok("Διαγράφηκε!"));
    }
}