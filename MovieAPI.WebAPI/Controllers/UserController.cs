using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application;
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

    //[HttpPost]
    //public async Task<IActionResult> CreateAsync(UserContract request)
    //{
    //    await _userService.CreateUserAsync(request);
    //    return Ok();
    //}

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync(UserRegisterContract request)
    {
        await _userService.RegisterUserAsync(request);
        return Ok("Successfully Register");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginAsync(UserLoginContract request)
    {
        var response = await _userService.LoginUserAsync(request);
        return Ok(response);
    }

    [Authorize(Roles = "Admin, User")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UserContract request)
    {
        await _userService.UpdateAsync(request);
        return Ok("Updated");
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var responseModel = await _userService.GetUsersAsync();
        return Ok(responseModel);
    }

    [Authorize(Roles = "Admin, User")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var responseModel = await _userService.GetUserByIdAsync(id);
        return Ok(responseModel);
    }

    [Authorize(Roles = "Admin, User")]
    [HttpGet("getrates/{id}")]
    public async Task<IActionResult> GetRatesAsync(int id)
    {
        var responseModel = await _userService.GetUserRateAsync(id);
        return Ok(responseModel);
    }

    [Authorize(Roles = "Admin, User")]
    [HttpGet("getcomments/{id}")]
    public async Task<IActionResult> GetCommentsAsync(int id)
    {
        var responseModel = await _userService.GetUserCommentAsync(id);
        return Ok(responseModel);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _userService.RemoveByIdAsync(id);
        return Ok("Delete successful");
    }

    [HttpPut("updaterole/{id}")]
    public async Task<IActionResult> EditUserRoleToAdminAsync(int id)
    {
        await _userService.EditUserRoleToAdminAsync(id);
        return Ok("Successfully edited user role to admin.");
    }

    [HttpGet("Pages")]
    public async Task<IActionResult> GetAllPagedAsync([FromQuery] PaginationFilter filter)
    {
        PaginationFilter paginationFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
        var responseModel = await _userService.GetPagedDataAsync(paginationFilter.PageNumber, paginationFilter.PageSize);
        return Ok(responseModel);
    }
}
