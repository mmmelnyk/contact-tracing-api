using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Requests
{
    public class DeleteUserRequest : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }
    }
}