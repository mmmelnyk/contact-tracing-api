using MediatR;
using System.ComponentModel.DataAnnotations;
using Presentation.Responses;

namespace Presentation.Requests
{
    public class UpdateUserRequest : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }
        public required string DeviceId { get; set; }
        public required string LastLogin { get; set; }
    }
}