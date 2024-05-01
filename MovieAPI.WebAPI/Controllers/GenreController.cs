using Microsoft.AspNetCore.Authorization;
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

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(GenreContract request)
    {
        //if(!ModelState.IsValid)
        //{
        //    return BadRequest(ModelState);
        //}

        await _genreService.AddAsync(request);
        return Ok("Success");
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(GenreContract request)
    {
        //if(!ModelState.IsValid)
        //{
        //    return BadRequest(ModelState);
        //}

        await _genreService.UpdateAsync(request);
        return Ok("Updated");
    }

    [Authorize(Roles = "Admin, User")]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var responseModel = await _genreService.GetAllAsync();
        return Ok(responseModel);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _genreService.RemoveByIdAsync(id);
        return Ok("Delete succescfull");
    }
}
