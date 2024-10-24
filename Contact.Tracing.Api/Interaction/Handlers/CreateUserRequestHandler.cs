using Contact.Tracing.Api.Interaction.Requests;
using Contact.Tracing.Api.Interaction.Responses;
using Contact.Tracing.Api.Services;
using MediatR;

namespace Contact.Tracing.Api.Interaction.Handlers;

internal sealed class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IUserService _userService;

    public CreateUserRequestHandler(IUserService userService)
    {
        ArgumentNullException.ThrowIfNull(userService);

        _userService = userService;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _userService.CreateAsync(request.PhoneNumber, cancellationToken);

        return new CreateUserResponse
        {
            Result = result,
        };
    }
}
