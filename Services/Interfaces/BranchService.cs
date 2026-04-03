using Microsoft.EntityFrameworkCore;
using PayrollSystem.Data;
using PayrollSystem.DTOs;
using PayrollSystem.Models;
using PayrollSystem.Services.Interfaces;

namespace PayrollSystem.Services.Implementations
{
    public class BranchService : IBranchService
    {
        private readonly PayrollContext _db;
        public BranchService(PayrollContext db)
        {
            _db = db;
        }

        public async Task<List<BranchResponseDto>> GetAllAsync()
        {
            var branches = await _db.Branches
                .Select(b => new BranchResponseDto
                {
                    Id = b.Id,
                    Area = b.Area,
                    CityName = b.City.Name
                })
                .ToListAsync();
            return branches; 
        }

        public async Task<BranchResponseDto?> GetByIdAsync(int id)
        {
            var branch = await _db.Branches
                .Where(b => b.Id == id)
                .Select(b => new BranchResponseDto
                {
                    Id = b.Id,
                    Area = b.Area,
                    CityName = b.City.Name
                })
                .FirstOrDefaultAsync();
            return branch;
        }

        public async Task<BranchResponseDto?> CreateAsync(CreateBranchDto dto)
        {
            var city = await _db.Cities
                .FindAsync(dto.CityId);
            if (city == null)
                return null;
            var branch = new Branch { Area = dto.Area , CityId = dto.CityId};
            _db.Branches.Add(branch);
            await _db.SaveChangesAsync();
            return new BranchResponseDto { Id = branch.Id,  Area = dto.Area , CityName = city.Name };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var branch = await _db.Branches.FindAsync(id);
            if (branch == null)
                return false;
            _db.Branches.Remove(branch);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}