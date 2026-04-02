using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    private readonly PayrollContext _db;

    public CityController(PayrollContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cities = await _db.Cities.ToListAsync();
        return Ok(cities);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var city = await _db.Cities.FindAsync(id);
        if (city == null)
            return NotFound("Η πόλη δεν βρέθηκε!");
        return Ok(city);
    }

    [HttpPost]
    public async Task<IActionResult> Create(City city)
    {
        _db.Cities.Add(city);
        await _db.SaveChangesAsync();
        return Ok(city);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var city = await _db.Cities.FindAsync(id);
        if (city == null)
            return NotFound("Η πόλη δεν βρέθηκε!");
        _db.Cities.Remove(city);
        await _db.SaveChangesAsync();
        return Ok("Διαγράφηκε!");
    }
}