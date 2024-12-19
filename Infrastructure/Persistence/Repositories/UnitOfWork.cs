using Domain.Repositories;

namespace Persistence.Repositories;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly RepositoryDbContext _dbContext;

    public UnitOfWork(RepositoryDbContext dbContext) => _dbContext = dbContext;

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _dbContext.SaveChangesAsync(cancellationToken);
}