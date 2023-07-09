using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WEB.AUTH.DAL.Exceptions;

namespace WEB.AUTH.DAL.Middlweare;

public class ExeptionHandlingMiddlweare
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExeptionHandlingMiddlweare> _logger;
    
    public ExeptionHandlingMiddlweare(RequestDelegate next, ILogger<ExeptionHandlingMiddlweare> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task Invoke(HttpContext context )
    {
        try
        {
            _logger.LogDebug("Operation completed successfully.", new { Operation = "DoSomething" });
            await _next.Invoke(context);
        }
        catch (BaseException ex)
        {
            HandleCustomException(context,ex);
        } 
        catch(Exception ex)
        {
            Handle(context, ex);
        }
    }

    private async Task HandleCustomException(HttpContext context, BaseException ex)
    {
        _logger.LogError(ex, "An error occurred while doing something.".ToUpper(),ex.Message);
        context.Response.StatusCode = ex.StatusCode;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(ex.Message).ConfigureAwait(false);
    }
    

    private async Task Handle(HttpContext context, Exception ex)
    {
        _logger.LogError(ex, "An error occurred while doing something.".ToUpper(),ex.Message);
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsync(ex.Message).ConfigureAwait(false);
    }
}