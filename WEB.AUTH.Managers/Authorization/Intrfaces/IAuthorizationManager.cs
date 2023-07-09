namespace WEB.AUTH.Managers.Authorization.Intrfaces;

public interface IAuthorizationManager
{
    string GenerateToken(string Id);
    bool VerifyToken(string token);
}