using Microsoft.AspNetCore.Http;

namespace WEB.AUTH.DAL.Middlweare;

public class ExeptionHandlingMiddlweare
{
    private readonly RequestDelegate next;
    
    public ExeptionHandlingMiddlweare(RequestDelegate _next)
    {
        next = _next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next.Invoke(context);
        }
        catch(Exception e)
        {
            Handle(e);
        }
    }
    private void Handle(Exception e)
    {
        Console.WriteLine(e.Message);
    }

}