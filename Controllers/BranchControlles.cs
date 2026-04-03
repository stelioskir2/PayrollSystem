using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class BranchController : ControllerBase
{
    private readonly PayrollContext _db;

    public BranchController(PayrollContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var branches = await _db.Branches
            .Select(b => new BranchResponseDto
            {
                Id = b.Id,
                Area = b.Area,
                CityName = b.City.Name
            })
            .ToListAsync();
        return Ok(branches);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
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
        if (branch == null)
            return NotFound("Το παράρτημα δεν βρέθηκε!");
        return Ok(branch);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBranchDto dto)
    {
        var city = await _db.Cities
            .FindAsync(dto.CityId);
        if (city == null)
            return NotFound("Η πόλη δεν βρέθηκε!");
        var branch = new Branch { Area = dto.Area , CityId = dto.CityId};
        _db.Branches.Add(branch);
        await _db.SaveChangesAsync();
        return Ok(new BranchResponseDto {Id = branch.Id , Area = branch.Area, CityName = city.Name});
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var branch = await _db.Branches.FindAsync(id);
        if (branch == null)
            return NotFound("Το παράρτημα δεν βρέθηκε!");
        _db.Branches.Remove(branch);
        await _db.SaveChangesAsync();
        return Ok("Διαγράφηκε!");
    }
}