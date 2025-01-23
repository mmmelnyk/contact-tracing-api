using Domain.Repositories;
using MediatR;
using Presentation.Requests;
using Presentation.Responses;

namespace Services.Handlers;

public class GetUserRequestHandler : IRequestHandler<GetUserRequest, GetUserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserRequestHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        var response = new GetUserResponse
        {
            Id = result.Id,
            DeviceId = result.DeviceId
        };

        return response;
    }
}