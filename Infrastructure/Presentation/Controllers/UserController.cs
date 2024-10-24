using Shared;
using Microsoft.AspNetCore.Mvc;
using Service.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/Users")]
public class UsersController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public UsersController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    [HttpGet]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        var Users = await _serviceManager.UserService.GetAllAsync(cancellationToken);

        return Ok(Users);
    }

    [HttpGet("{UserId:guid}")]
    public async Task<IActionResult> GetUserById(Guid UserId, CancellationToken cancellationToken)
    {
        var UserDto = await _serviceManager.UserService.GetByIdAsync(UserId, cancellationToken);

        return Ok(UserDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserDto user)
    {
        var newUser = await _serviceManager.UserService.CreateAsync(user);

        return CreatedAtAction(nameof(GetUserById), new { UserId = newUser.Id }, newUser);
    }

    [HttpDelete("{UserId:guid}")]
    public async Task<IActionResult> DeleteUser(Guid UserId, CancellationToken cancellationToken)
    {
        //Test
        await _serviceManager.UserService.DeleteAsync(UserId, cancellationToken);

        return NoContent();
    }
}
