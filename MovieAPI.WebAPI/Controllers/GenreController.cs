using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.DTOs;
using MovieAPI.Application.Interfaces;

namespace MovieAPI.WebAPI.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class GenreController : Controller
{
    private readonly IGenreService _genreService;
    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(GenreContract request)
    {
        await _genreService.AddAsync(request);
        return Ok("Success");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(GenreContract request)
    {
        await _genreService.UpdateAsync(request);
        return Ok("Updated");
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var responseModel = await _genreService.GetAllAsync();
        return Ok(responseModel);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _genreService.RemoveByIdAsync(id);
        return Ok("Delete succescfull");
    }
}
