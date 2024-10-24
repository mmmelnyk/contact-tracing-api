
using Contact.Tracing.Api.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Tracing.Api.Controllers;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Produces("application/json")]
[Consumes("application/json")]
[Route(ServiceConstants.RoutePrefix)]
public class ApiControllerBase : ControllerBase
{
    private ISender? _mediator;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
