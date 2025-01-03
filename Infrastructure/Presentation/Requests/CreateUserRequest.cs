using MediatR;
using Presentation.Responses;

namespace Presentation.Requests
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public Guid Id { get; set; }
        public required string DeviceId { get; set; }
        public required DateTime LastLogin { get; set; }
    }
}