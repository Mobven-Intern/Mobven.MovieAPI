using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.DTOs;
using MovieAPI.Application.Interfaces;
using MovieAPI.Application.Services;

namespace MovieAPI.WebAPI.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class MovieController : Controller
{
    private readonly IMovieService _movieService;
    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(MovieCreateContract request)
    {
        await _movieService.CreateMovieAsync(request);
        return Ok("Success");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(MovieUpdateContract request)
    {
        await _movieService.UpdateMovieAsync(request);
        return Ok("Updated");
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var responseModel = await _movieService.GetMoviesAsync();
        return Ok(responseModel);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var responseModel = await _movieService.GetMovieByIdAsync(id);
        return Ok(responseModel);
    }

    [HttpGet("comments/{id}")]
    public async Task<IActionResult> GetCommentsAsync(int id)
    {
        var responseModel = await _movieService.GetMovieCommentsAsync(id);
        return Ok(responseModel);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _movieService.RemoveByIdAsync(id);
        return Ok("Delete succescfull");
    }
}
