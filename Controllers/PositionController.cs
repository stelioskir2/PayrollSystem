using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]

public class PositionController : ControllerBase
{
    private readonly PayrollContext _db;

    public PositionController(PayrollContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var positions = await _db.Positions
            .ToListAsync();
        return Ok(positions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var position = await _db.Positions
            .FirstOrDefaultAsync(p => p.Id == id);
        if (position == null)
            return NotFound("Η συγκεκριμένη θέση δεν βρέθηκε!");
        return Ok(position);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Position position)
    {
        _db.Positions.Add(position);
        await _db.SaveChangesAsync();
        return Ok(position);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Position updated_position)
    {
        var position = await _db.Positions
            .FirstOrDefaultAsync(p => p.Id == id);
        if (position == null)
            return NotFound("Η συγκεκριμένη θέση δεν βρέθηκε!");
        position.Title = updated_position.Title;
        await _db.SaveChangesAsync();
        return Ok("Ενημερώθηκε!");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var position = await _db.Positions
            .FirstOrDefaultAsync(p => p.Id == id);
        if (position == null)
            return NotFound("Η συγκεκριμένη θέση δεν βρέθηκε!");
        _db.Positions.Remove(position);
        await _db.SaveChangesAsync();
        return Ok("Διαγράφηκε!");
    }
}
