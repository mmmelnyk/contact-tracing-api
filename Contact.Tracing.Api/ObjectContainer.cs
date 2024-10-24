using MediatR;
using System.Text.Json;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Contact.Tracing.Api.Services;
using FluentValidation;

namespace Contact.Tracing.Api;

public static class ObjectContainer
{
    public static void Init(IServiceCollection services, IConfiguration config)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
            });

        services.AddMediatR(Assembly.GetExecutingAssembly());

        var executingAssembly = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(executingAssembly)
                .AddValidatorsFromAssembly(executingAssembly);

        services.AddFluentValidationAutoValidation();

        services.AddVersionedApiExplorer(o =>
        {
            o.GroupNameFormat = "'v'VVV";
            o.SubstituteApiVersionInUrl = true;
        });

        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
        });

        services.AddServices(config);
    }

    private static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        //Services
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
