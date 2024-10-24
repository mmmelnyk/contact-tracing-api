using Contact.Tracing.Api.Interaction.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Tracing.Api.Controllers;

public class UserController : ApiControllerBase
{
    [HttpPost("create")]
    //[Authorize(Policy = "admin")] TODO: implement
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return Accepted(result);
    }
}
