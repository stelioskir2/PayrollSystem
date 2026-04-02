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
            .Include(b => b.City)
            .ToListAsync();
        return Ok(branches);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var branch = await _db.Branches
            .Include(b => b.City)
            .FirstOrDefaultAsync(b => b.Id == id);
        if (branch == null)
            return NotFound("Το παράρτημα δεν βρέθηκε!");
        return Ok(branch);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Branch branch)
    {
        var city = await _db.Cities.FindAsync(branch.CityId);
        if (city == null)
            return NotFound("Η πόλη δεν βρέθηκε!");
        _db.Branches.Add(branch);
        await _db.SaveChangesAsync();
        return Ok(branch);
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