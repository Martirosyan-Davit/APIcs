namespace WEB.AUTH.Managers.Authorization.Intrfaces;

public interface ILoggerManager
{
    Task ErrorAsync(Exception exception, object? relatedObject = null);
    Task DebugAsync(string massage, object? relatedObject = null);
    Task WarningAsync(string massage, object? relatedObject = null);
}