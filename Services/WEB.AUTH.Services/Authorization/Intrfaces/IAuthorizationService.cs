namespace WEB.AUTH.Services.Authorization.Intrfaces;

public interface IAuthorizationService
{
    string GenerateToken(string Id);
    bool VerifyToken(string token);
}