using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.DTOs;
using MovieAPI.Application.Interfaces;

namespace MovieAPI.WebAPI.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(IUserService service)
    {
        _userService = service;
    }

    [HttpPost]

    public async Task<IActionResult> CreateAsync(UserContract request)
    {
        await _userService.CreateUserAsync(request);
        return Ok();
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync(UserRegisterContract request)
    {
        await _userService.RegisterUserAsync(request);
        return Ok("Successfully Register");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginAsync(UserLoginContract request)
    {
        await _userService.LoginUserAsync(request);
        return Ok("Successfully Login");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UserContract request)
    {
        await _userService.UpdateUserAsync(request);
        return Ok("Updated");
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var responseModel = await _userService.GetUsersAsync();
        return Ok(responseModel);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var responseModel = await _userService.GetUserByIdAsync(id);
        return Ok(responseModel);
    }

    [HttpGet("getrates/{id}")]
    public async Task<IActionResult> GetRatesAsync(int id)
    {
        var responseModel = await _userService.GetUserRateAsync(id);
        return Ok(responseModel);
    }

    [HttpGet("getcomments/{id}")]
    public async Task<IActionResult> GetCommentsAsync(int id)
    {
        var responseModel = await _userService.GetUserCommentAsync(id);
        return Ok(responseModel);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _userService.RemoveByIdAsync(id);
        return Ok("Delete succescfull");
    }
}
