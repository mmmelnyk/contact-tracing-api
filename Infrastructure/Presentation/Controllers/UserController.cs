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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(string id, CancellationToken cancellationToken)
    {
        var request = new GetUserRequest { Id = Guid.Parse(id) };
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
