using PayrollSystem.DTOs;

namespace PayrollSystem.Services.Interfaces 
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponseDto>> GetAllAsync();
        Task<EmployeeResponseDto?> GetByIdAsync(int registrationnumber);
        Task<EmployeeResponseDto?> CreateAsync(CreateEmployeeDto dto);
        Task<bool> PutAsync(int registrationnumber , UpdateEmployeeDto dto);
        Task<bool> DeleteAsync(int registrationnumber);
    }
}
