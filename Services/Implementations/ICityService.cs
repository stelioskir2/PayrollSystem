using PayrollSystem.Models;
using PayrollSystem.DTOs;

namespace PayrollSystem.Services.Interfaces 
{
    public interface ICityService
    {
        Task<List<City>> GetAllAsync();
        Task<City?> GetByIdAsync(int id);    
        Task<CityResponseDto> CreateAsync(CreateCityDto dto);
        Task<bool> DeleteAsync(int id);
    }
}    