using Domain.Repositories;
using MediatR;
using Presentation.Requests;
using Presentation.Responses;

namespace Services.Handlers;

public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest, bool>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserRequestHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        await _userRepository.RemoveAsync(request.Id, cancellationToken);

        return true;
    }
}