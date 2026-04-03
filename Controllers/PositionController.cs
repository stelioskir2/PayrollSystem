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
            .Select(p => new PositionResponseDto
            {
                Id = p.Id,
                Title = p.Title
            })
            .ToListAsync();
        return Ok(positions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var position = await _db.Positions
            .Where(p => p.Id == id)
            .Select(p => new PositionResponseDto
            {
                Id = id,
                Title = p.Title
            })
            .FirstOrDefaultAsync();
        if (position == null)
            return NotFound("Η συγκεκριμένη θέση δεν βρέθηκε!");
        return Ok(position);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePositionDto dto)
    {
        var position = new Position{Title = dto.Title};
        _db.Positions.Add(position);
        await _db.SaveChangesAsync();
        return Ok(new PositionResponseDto {Id = position.Id , Title = position.Title});
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id , UpdatePositionDto dto)
    {
        var position = await _db.Positions
            .FirstOrDefaultAsync(p => p.Id == id);
        if (position == null)
            return NotFound("Η συγκεκριμένη θέση δεν βρέθηκε!");
        position.Title = dto.Title;
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
