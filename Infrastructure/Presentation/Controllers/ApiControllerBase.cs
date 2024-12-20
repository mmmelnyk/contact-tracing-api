using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shared.Configuration;

namespace Presentation.Controllers;

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