using MediatR;

namespace Presentation.Requests
{
    public class CreateUserRequest : IRequest<int>
    {
        public Guid Id { get; set; }
        public required string DeviceId { get; set; }
        public required string LastLogin { get; set; }
    }
}