using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Requests
{
    public class DeleteUserRequest : IRequest<int>
    {
        [Required]
        public Guid Id { get; set; }
    }
}