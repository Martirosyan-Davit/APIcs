using Microsoft.Extensions.Logging;

namespace WEB.AUTH.Managers.Loger;

public class LoggerManager
{
    private readonly ILoggerFactory _loggerFactory;

    public LoggerManager(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
    }
}