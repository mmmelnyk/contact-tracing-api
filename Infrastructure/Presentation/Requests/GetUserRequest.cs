using MediatR;
using System.ComponentModel.DataAnnotations;
using Presentation.Responses;

namespace Presentation.Requests
{
    public class GetUserRequest : IRequest<GetUserResponse>
    {
        [Required]
        public Guid Id { get; set; }
    }
}