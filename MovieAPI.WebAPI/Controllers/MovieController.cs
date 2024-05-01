using Microsoft.AspNetCore.Authorization;
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

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(MovieCreateContract request)
    {
        //if(!ModelState.IsValid)
        //{
        //    return BadRequest(ModelState);
        //}

        await _movieService.CreateMovieAsync(request);
        return Ok("Success");
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(MovieUpdateContract request)
    {
        //if(!ModelState.IsValid)
        //{
        //    return BadRequest(ModelState);
        //}

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

    [HttpGet("getcomments/{id}")]
    public async Task<IActionResult> GetCommentsAsync(int id)
    {
        var responseModel = await _movieService.GetMovieCommentsAsync(id);
        return Ok(responseModel);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _movieService.RemoveByIdAsync(id);
        return Ok("Delete succescfull");
    }
}
