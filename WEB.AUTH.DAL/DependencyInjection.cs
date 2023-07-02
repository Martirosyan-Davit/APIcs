using Microsoft.Extensions.DependencyInjection;
using WEB.AUTH.DAL.Interface;
using WEB.AUTH.DAL.Repository;

namespace WEB.AUTH.DAL;

public static class DependencyInjection
{
    public static void AddDal(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
}