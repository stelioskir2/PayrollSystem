using PayrollSystem.DTOs;
using PayrollSystem.Models;

namespace PayrollSystem.Services.Interfaces 
{
    public interface IPositionService
    {
        Task<List<PositionResponseDto>> GetAllAsync();
        Task<PositionResponseDto?> GetByIdAsync(int id);
        Task<PositionResponseDto> CreateAsync(CreatePositionDto dto);
        Task<bool> PutAsync(int id , UpdatePositionDto dto);
        Task<bool> DeleteAsync(int id);
    }
}