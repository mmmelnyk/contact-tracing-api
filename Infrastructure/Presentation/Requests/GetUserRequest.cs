using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Requests
{
    public class GetUserRequest : IRequest<int>
    {
        [Required]
        public Guid Id { get; set; }
    }
}