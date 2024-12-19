using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly RepositoryDbContext _dbContext;

    public UserRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbContext.Users.ToListAsync(cancellationToken);

    public async Task<User> GetByIdAsync(Guid UserId, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == UserId, cancellationToken);
        return user ?? default;
    }

    public async Task<Guid> InsertAsync(User user, CancellationToken cancellationToken = default) {
        var entityEntry = await _dbContext.Users.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return entityEntry.Entity.Id;
    }

    public async Task RemoveAsync(User user, CancellationToken cancellationToken = default)
    {
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
