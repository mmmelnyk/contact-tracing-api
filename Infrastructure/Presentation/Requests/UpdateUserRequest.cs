using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Requests
{
    public class UpdateUserRequest : IRequest<int>
    {
        [Required]
        public Guid Id { get; set; }
        public required string DeviceId { get; set; }
        public required string LastLogin { get; set; }
    }
}