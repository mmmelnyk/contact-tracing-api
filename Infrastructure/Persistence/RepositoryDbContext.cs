using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public sealed class RepositoryDbContext : DbContext
{
    public RepositoryDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
}
