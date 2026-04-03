using Microsoft.AspNetCore.Mvc;
using PayrollSystem.Services.Interfaces;
using PayrollSystem.DTOs;

[ApiController]
[Route("api/[controller]")]
public class BranchController : ControllerBase
{
    private readonly IBranchService _branchService;

    public BranchController(IBranchService branchService)
    {
        _branchService = branchService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var branches = await _branchService.GetAllAsync();
        return Ok(branches);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var branch = await _branchService.GetByIdAsync(id);
        if (branch == null)
            return NotFound("Το παράρτημα δεν βρέθηκε!");
        return Ok(branch);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBranchDto dto)
    {
        var branch = await _branchService.CreateAsync(dto);
        if (branch == null)
            return NotFound("Η πόλη δεν βρέθηκε!");
        return Ok(branch);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var branch = await _branchService.DeleteAsync(id);
        if (!branch)
            return NotFound("Το παραρτημα δεν βρέθηκε δεν βρέθηκε!");
        return Ok("Διαγράφηκε!");
    }
}