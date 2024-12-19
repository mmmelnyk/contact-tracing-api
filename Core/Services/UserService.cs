using Service.Abstractions;
using Shared;

namespace Services;

public class UserService(IMediator mediator) : IUserService
{
    public Task AddUser()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> CreateAsync(UserDto UserDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid ownerId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetByIdAsync(Guid ownerId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
