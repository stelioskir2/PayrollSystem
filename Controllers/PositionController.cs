using Microsoft.AspNetCore.Mvc;
using PayrollSystem.Services.Interfaces;
using PayrollSystem.DTOs;

[ApiController]
[Route("api/[controller]")]

public class PositionController : ControllerBase
{
    private readonly IPositionService _positionService;

    public PositionController(IPositionService positionService)
    {
        _positionService = positionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var positions = await _positionService.GetAllAsync();
        return Ok(positions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var position = await _positionService.GetByIdAsync(id);
        if (position == null)
            return NotFound("Η συγκεκριμένη θέση δεν βρέθηκε!");
        return Ok(position);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePositionDto dto)
    {
        var position = await _positionService.CreateAsync(dto);
        return Ok(position);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id , UpdatePositionDto dto)
    {
        var position = await _positionService.PutAsync(id, dto);
        if (!position)
            return NotFound("Η συγκεκριμένη θέση δεν βρέθηκε!");
        return Ok("Ενημερώθηκε!");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var position = await _positionService.DeleteAsync(id);
        if (!position)
            return NotFound("Η συγκεκριμένη θέση δεν βρέθηκε!");
        return Ok("Διαγράφηκε!");
    }
}
