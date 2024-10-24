using Contact.Tracing.Api.Interaction.Responses;
using MediatR;

namespace Contact.Tracing.Api.Interaction.Requests;

public record CreateUserRequest : IRequest<CreateUserResponse>
{
    public required string PhoneNumber { get; init; }
}
