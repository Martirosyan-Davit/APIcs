using Microsoft.AspNetCore.Builder;
using WEB.AUTH.DAL.Middlweare;

namespace WEB.AUTH.DAL.Configurations;
//
// not config 
public static class MiddlewareConfiguration
{
    public static void AddMiddleware(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<ExeptionHandlingMiddlweare>();
    }
}