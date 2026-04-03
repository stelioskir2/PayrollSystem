using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using PayrollSystem.Data;
using PayrollSystem.DTOs;
using PayrollSystem.Models;
using PayrollSystem.Services.Interfaces;

namespace PayrollSystem.Services.Implementations
{
    public class CityService : ICityService
    {
        private readonly PayrollContext _db;
        public CityService(PayrollContext db)
        {
            _db = db;
        }
        public async Task<List<City>> GetAllAsync()
        {
            var cities = await _db.Cities
                .ToListAsync();
            return cities;
        }

        public async Task<City?> GetByIdAsync(int id)
        {
            var city = await _db.Cities
                .FindAsync(id);
            return city;
        }

        public async Task<CityResponseDto> CreateAsync(CreateCityDto dto)
        {
            var city = new City { Name = dto.Name };
            _db.Cities.Add(city);
            await _db.SaveChangesAsync();
            return new CityResponseDto { Id = city.Id, Name = city.Name };
        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            var city = await _db.Cities.FindAsync(id);
            if (city == null)
                return false;
            _db.Cities.Remove(city);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}