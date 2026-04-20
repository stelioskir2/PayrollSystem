using Microsoft.AspNetCore.Mvc;
using PayrollSystem.Services.Interfaces;
using PayrollSystem.DTOs;
using PayrollSystem.Helpers;

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
        return Ok(ApiResponse.Ok(branches));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var branch = await _branchService.GetByIdAsync(id);
        if (branch == null)
            return NotFound(ApiResponse.NotFound("Το παράρτημα δεν βρέθηκε!"));
        return Ok(ApiResponse.Ok(branch));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBranchDto dto)
    {
        var branch = await _branchService.CreateAsync(dto);
        if (branch == null)
            return NotFound(ApiResponse.NotFound("Η πόλη δεν βρέθηκε!"));
        return Ok(ApiResponse.Ok(branch));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var branch = await _branchService.DeleteAsync(id);
        if (!branch)
            return NotFound(ApiResponse.NotFound("Το παραρτημα δεν βρέθηκε!"));
        return Ok(ApiResponse.Ok("Διαγράφηκε!"));
    }
}