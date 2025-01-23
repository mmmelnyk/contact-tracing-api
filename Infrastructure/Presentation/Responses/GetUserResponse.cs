using MediatR;

namespace Presentation.Responses;

public class GetUserResponse
{
    public Guid Id { get; set; }
    public string DeviceId { get; set; }
    public string LastLogin { get; set; }
}