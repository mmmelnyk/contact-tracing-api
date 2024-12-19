using MediatR;

namespace ContactTracingAPI.Interaction.Requests
{
    public class AddUserRequest : IRequest<int>
    {
        public Guid Id { get; set; }
        public required string DeviceId { get; set; }
        public required string LastLogin { get; set; }
    }
}