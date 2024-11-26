using Api.AccessPolicies;
using Application.Dtos;
using Application.Services;
using IdentityApi.Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    private readonly string _userId;

    public UserController(UserService userService, IHttpContextAccessor httpContextAccessor)
    {
        _userService = userService;
        _userId = httpContextAccessor.HttpContext?.User?.Claims?.SingleOrDefault(c => c.Type == "id")?.Value ?? Guid.Empty.ToString();
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetUserById()
    {
        var user = await _userService.GetUserByIdAsync(_userId);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpGet("health")]
    public IActionResult HealthCheck()
    {
        return Ok("User API is up and running.");
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto request)
    {
        var success = await _userService.CreateUserAsync(request);
        if (success is false)
        {
            return BadRequest();
        }
        return Created();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto request)
    {
        var token = await _userService.LoginAsync(request);
        return Ok(token);
    }

    [HttpPut]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto request)
    {
        var user = await _userService.UpdateUserAsync(_userId, request);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpDelete]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUser()
    {
        var success = await _userService.DeleteUserAsync(_userId);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    } 
}