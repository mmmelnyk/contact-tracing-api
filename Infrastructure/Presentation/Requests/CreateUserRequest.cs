using MediatR;
using Presentation.Responses;

namespace Presentation.Requests
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public required string DeviceId { get; set; }
    }
}