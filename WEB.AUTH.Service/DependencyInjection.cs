
using Microsoft.Extensions.DependencyInjection;
using WEB.AUTH.Service.Implementation;
using WEB.AUTH.Service.Interfaces;

namespace WEB.AUTH.Service;

public static class DependencyInjection
{
    public static void AddBLL(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
    }
}