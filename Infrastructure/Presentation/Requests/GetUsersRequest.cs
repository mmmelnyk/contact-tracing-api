using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Requests
{
    public class GetUsersRequest : IRequest<int>
    {
    }
}