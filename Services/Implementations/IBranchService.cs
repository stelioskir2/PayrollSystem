using PayrollSystem.DTOs;

namespace PayrollSystem.Services.Interfaces 
{
    public interface IBranchService
    {
        Task<List<BranchResponseDto>> GetAllAsync();
        Task<BranchResponseDto?> GetByIdAsync(int id);
        Task<BranchResponseDto?> CreateAsync(CreateBranchDto dto);
        Task<bool> DeleteAsync(int id);
    }
}