using Domain.Repositories;
using MediatR;
using Presentation.Requests;
using Domain.Entities;

namespace Services.Handlers;

public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, bool>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserRequestHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = request.Id,
            DeviceId = request.DeviceId
        };
        await _userRepository.UpdateAsync(user, cancellationToken);

        return true;
    }
}