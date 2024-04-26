using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.DTOs;
using MovieAPI.Application.Interfaces;
using MovieAPI.Application.Services;

namespace MovieAPI.WebAPI.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class TagController : Controller
{
    private readonly ITagService _tagService;
    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(TagContract request)
    {
        await _tagService.AddAsync(request);
        return Ok("Success");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(TagContract request)
    {
        await _tagService.UpdateAsync(request);
        return Ok("Updated");
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var responseModel = await _tagService.GetAllAsync();
        return Ok(responseModel);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _tagService.RemoveByIdAsync(id);
        return Ok("Delete succescfull");
    }
}
