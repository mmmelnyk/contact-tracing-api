using Persistence;
using Microsoft.EntityFrameworkCore;
using Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddDbContextPool<RepositoryDbContext>(b =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");

    b.UseNpgsql(connectionString);
});

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
