using Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ContactTracingAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddDbContextPool<RepositoryDbContext>(b =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");

    b.UseNpgsql(connectionString);
});

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ContactTracingAPI V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

var connectionString = builder.Configuration.GetConnectionString("ContactTracingDb");
builder.Services.AddDbContext<RepositoryDbContext>(options => 
    options.UseNpgsql(connectionString));

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
