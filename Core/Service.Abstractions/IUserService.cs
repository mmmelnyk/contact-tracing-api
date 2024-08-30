using Shared;

namespace Service.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<UserDto> GetByIdAsync(Guid ownerId, CancellationToken cancellationToken = default);

        Task<UserDto> CreateAsync(UserDto UserDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid ownerId, CancellationToken cancellationToken = default);
    }
}