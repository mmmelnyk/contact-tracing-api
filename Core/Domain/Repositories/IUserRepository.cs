using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<User> GetByIdAsync(Guid UserId, CancellationToken cancellationToken = default);

        Task<Guid> InsertAsync(User user, CancellationToken cancellationToken = default);

        Task RemoveAsync(Guid UserId, CancellationToken cancellationToken = default);

        Task UpdateAsync(User user, CancellationToken cancellationToken = default);
    }
}