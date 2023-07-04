namespace WEB.AUTH.Services.Model;

public class JwtModel
{
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public string? SecretKey { get; set; }
    public double? ExpirationInMinutes { get; set; }
}