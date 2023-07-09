using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WEB.AUTH.Managers.Authorization.Implementationes;
using WEB.AUTH.Managers.Authorization.Intrfaces;
using WEB.AUTH.Managers.Loger;

namespace WEB.AUTH.Managers;

public static class DependencyInjection
{
    public static void AddJwtAuthentication(this IServiceCollection services)
    {
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
        });
    }

    public static void AddLogger(this IServiceCollection service)
    {
        service.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.AddDebug();
        });
    }

    public static void AddLoggerFactory(this IServiceCollection service)
    {
        service.AddScoped<LoggerManager>();
    }

    public static void AddAuthorizationManager(this IServiceCollection service)
    {
        service.AddScoped<IAuthorizationManager, AuthorizationManager>();
    }
}