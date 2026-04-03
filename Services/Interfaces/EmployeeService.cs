using Microsoft.EntityFrameworkCore;
using PayrollSystem.Data;
using PayrollSystem.DTOs;
using PayrollSystem.Models;
using PayrollSystem.Services.Interfaces;

namespace PayrollSystem.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly PayrollContext _db;
        public EmployeeService(PayrollContext db)
        {
            _db = db;
        }
        public async Task<List<EmployeeResponseDto>> GetAllAsync()
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
            return employees;
        }
        public async Task<EmployeeResponseDto?> GetByIdAsync(int registrationnumber)
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
                return null;
            return employee;  
        }
        public async Task<EmployeeResponseDto?> CreateAsync(CreateEmployeeDto dto)
        {
            var branch = await _db.Branches
                .Include(b => b.City)
                .FirstOrDefaultAsync(b => b.Id == dto.BranchId);
            if (branch == null)
                return null;
            var position = await _db.Positions
                .FirstOrDefaultAsync(p => p.Id == dto.PositionId);
            if (position == null)
                return null;
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
            return new EmployeeResponseDto
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
            };
        }
        public async Task<bool> PutAsync(int registrationnumber , UpdateEmployeeDto dto)
        {
            var employee = await _db.Employees
                .FindAsync(registrationnumber);
            if (employee == null) 
                return false;
            employee.Address = dto.Address;
            employee.Phone = dto.Phone;
            employee.Salary = dto.Salary;
            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int registrationnumber)
        {
            var employee = await _db.Employees
                .FindAsync(registrationnumber);
            if (employee == null) 
                return false;
            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}