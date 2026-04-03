using Microsoft.EntityFrameworkCore;
using PayrollSystem.Data;
using PayrollSystem.DTOs;
using PayrollSystem.Models;
using PayrollSystem.Services.Interfaces;

namespace PayrollSystem.Services.Implementations
{
    public class PositionService : IPositionService
    {
        private readonly PayrollContext _db;
        public PositionService(PayrollContext db)
        {
            _db = db;
        }

        public async Task<List<PositionResponseDto>> GetAllAsync()
        {
            var positions = await _db.Positions
                .Select(p => new PositionResponseDto
                {
                    Id = p.Id,
                    Title = p.Title
                })
                .ToListAsync();
            return positions;
        }

        public async Task<PositionResponseDto?> GetByIdAsync(int id)
        {
            var position = await _db.Positions
                .FindAsync(id);
            if (position == null)
                return null;
            return new PositionResponseDto {Id = position.Id , Title = position.Title};
        }

        public async Task<PositionResponseDto> CreateAsync(CreatePositionDto dto)
        {
            var position = new Position{Title = dto.Title};
            _db.Positions.Add(position);
            await _db.SaveChangesAsync();
            return new PositionResponseDto {Id = position.Id , Title = position.Title};
        }

        public async Task<bool> PutAsync(int id, UpdatePositionDto dto)
        {
            var position = await _db.Positions
                .FindAsync(id);
            if (position == null)
                return false;
            position.Title = dto.Title;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var position = await _db.Positions
                .FindAsync(id);
            if (position == null)
                return false;
            _db.Positions.Remove(position);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}