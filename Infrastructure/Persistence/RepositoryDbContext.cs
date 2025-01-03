using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence;

public sealed class RepositoryDbContext : DbContext
{
    protected readonly IConfiguration Configuration;
    public RepositoryDbContext(IConfiguration configuration) => Configuration = configuration;

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("ContactTracingDb"));
    }
}
