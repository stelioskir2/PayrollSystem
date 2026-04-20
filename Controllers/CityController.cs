using Microsoft.AspNetCore.Mvc;
using PayrollSystem.Services.Interfaces;
using PayrollSystem.DTOs;
using PayrollSystem.Helpers; 


[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    private readonly ICityService _cityService;
    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }   

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cities = await _cityService.GetAllAsync();
        return Ok(ApiResponse.Ok(cities));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var city = await _cityService.GetByIdAsync(id);
        if (city == null)
            return NotFound(ApiResponse.NotFound("Η πόλη δεν βρέθηκε!"));
        return Ok(ApiResponse.Ok(city));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCityDto dto)
    {
        var city = await _cityService.CreateAsync(dto);
        return Ok(ApiResponse.Ok(city));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var found = await _cityService.DeleteAsync(id);
        if (!found)
            return NotFound(ApiResponse.NotFound("Η πόλη δεν βρέθηκε!"));
        return Ok(ApiResponse.Ok("Διαγράφηκε!"));      
    }
}