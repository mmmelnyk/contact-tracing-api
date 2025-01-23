using MediatR;
using Presentation.Responses;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Requests
{
    public class GetUsersRequest : IRequest<List<GetUserResponse>>
    {
    }
}