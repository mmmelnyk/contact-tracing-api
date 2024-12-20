using Shared;
using Microsoft.AspNetCore.Mvc;
using Service.Abstractions;
using Presentation.Requests;

namespace Presentation.Controllers;

[ApiController]
[Route("api/Users")]
public class UsersController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        var request = new GetUsersRequest();
        var result = await Mediator.Send(request, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// GetUserById
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("get")]
    public async Task<IActionResult> GetUserById(GetUserRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return Accepted(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return Accepted(result);
    }
}
