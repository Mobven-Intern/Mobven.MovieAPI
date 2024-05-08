using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.DTOs;
using MovieAPI.Application.Interfaces;

namespace MovieAPI.WebAPI.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class RateController : Controller
{
    private readonly IRateService _rateService;
    public RateController(IRateService rateService)
    {
        _rateService = rateService;
    }
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(RateContract request)
    {
        await _rateService.AddAsync(request);
        return Ok("Success");
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(RateContract request)
    {
        await _rateService.UpdateAsync(request);
        return Ok("Updated");
    }

    [Authorize(Roles = "Admin, User")]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var responseModel = await _rateService.GetAllAsync();
        return Ok(responseModel);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _rateService.RemoveByIdAsync(id);
        return Ok("Delete succescfull");
    }
}
