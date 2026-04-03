using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]

public class EmployeeController : ControllerBase
{
    private readonly PayrollContext _db;

    public EmployeeController(PayrollContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _db.Employees
            .Select(e => new EmployeeResponseDto
            {
                RegistrationNumber = e.RegistrationNumber,
                FirstName = e.FirstName,
                LastName = e.LastName,
                BranchArea = e.Branch.Area,
                CityName = e.Branch.City.Name,
                PositionTitle = e.Position.Title,
                Salary = e.Salary,
                Address = e.Address,
                Phone = e.Phone
            })
            .ToListAsync();
        return Ok(employees);
    }

    [HttpGet("{registrationnumber}")]
    public async Task<IActionResult> GetById(int registrationnumber)
    {
        var employee = await _db.Employees
            .Where(e => e.RegistrationNumber == registrationnumber)
            .Select(e => new EmployeeResponseDto
            {
                RegistrationNumber = e.RegistrationNumber,
                FirstName = e.FirstName,
                LastName = e.LastName,
                BranchArea = e.Branch.Area,
                CityName = e.Branch.City.Name,
                PositionTitle = e.Position.Title,
                Salary = e.Salary,
                Address = e.Address,
                Phone = e.Phone
            })
            .FirstOrDefaultAsync();
        if (employee == null) 
            return NotFound("Δεν υπάρχει υπάλληλος με αυτό το ΑΜ!");
        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeDto dto)
    {
        var branch = await _db.Branches
            .Include(b => b.City)
            .FirstOrDefaultAsync(b => b.Id == dto.BranchId);
        if (branch == null)
            return NotFound("Δεν υπάρχει τέτοιο Branch");
        var position = await _db.Positions
            .FirstOrDefaultAsync(p => p.Id == dto.PositionId);
        if (position == null)
            return NotFound("Δεν υπάρχει τέτοιο Position"); 
        var employee = new Employee
        {
            RegistrationNumber = dto.RegistrationNumber,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            BranchId = dto.BranchId,
            PositionId = dto.PositionId,
            Salary = dto.Salary,
            Address = dto.Address,
            Phone = dto.Phone
        };
        _db.Employees.Add(employee);
        await _db.SaveChangesAsync();
        return Ok(new EmployeeResponseDto
        {
            RegistrationNumber = employee.RegistrationNumber,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            BranchArea = branch.Area,
            CityName = branch.City.Name,
            PositionTitle = position.Title,
            Salary = employee.Salary,
            Address = employee.Address,
            Phone = employee.Phone
        });
    }

    [HttpPut("{registrationnumber}")]
    public async Task<IActionResult> Put(int registrationnumber, UpdateEmployeeDto dto)
    {
        var employee = await _db.Employees
            .FindAsync(registrationnumber);
        if (employee == null) 
            return NotFound("Δεν υπάρχει υπάλληλος με αυτό το ΑΜ!");
        employee.Address = dto.Address;
        employee.Phone = dto.Phone;
        employee.Salary = dto.Salary;
        await _db.SaveChangesAsync();
        return Ok("Ενημερώθηκε!");
    }

    [HttpDelete("{registrationnumber}")]
    public async Task<IActionResult> Delete(int registrationnumber)
    {
        var employee = await _db.Employees
            .FindAsync(registrationnumber);
        if (employee == null) 
            return NotFound("Δεν υπάρχει υπάλληλος με αυτό το ΑΜ!");
        _db.Employees.Remove(employee);
        await _db.SaveChangesAsync();
        return Ok("Διαγράφηκε!");
    }
}