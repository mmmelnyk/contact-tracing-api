using Persistence;
using Microsoft.EntityFrameworkCore;
using ContactTracingAPI.Middleware;
using Services.Handlers;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(CreateUserRequestHandler).Assembly
));

builder.Services.AddScoped<Domain.Repositories.IUserRepository, UserRepository>();

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ContactTracingDb");
builder.Services.AddDbContext<RepositoryDbContext>(options => 
    options.UseNpgsql(connectionString));

// Register the ExceptionHandlingMiddleware
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

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

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
