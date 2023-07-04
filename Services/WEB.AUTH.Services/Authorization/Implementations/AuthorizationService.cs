using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WEB.AUTH.Services.Authorization.Intrfaces;

namespace WEB.AUTH.Services.Authorization.Implementationes;

public class AuthorizationService : IAuthorizationService
{
    private readonly IConfiguration _configuration;

    public AuthorizationService (IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string GenerateToken(string Id)
    {
        var JwtSetings = _configuration.GetSection("Jwt");
        var SecretKey = JwtSetings["SecretKey"];
        var SigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        var Claims = new[]
        {
            new Claim("Id", Id)
        };
        var TokenHendler = new JwtSecurityTokenHandler();
        var TokenDescription = new SecurityTokenDescriptor()
        {
            Issuer = JwtSetings["Issuer"],
            Audience = JwtSetings["Audience"],
            Subject = new ClaimsIdentity(Claims),
            Expires = DateTime.UtcNow.AddMinutes(1000),
            SigningCredentials = new SigningCredentials(SigningKey, SecurityAlgorithms.Aes128CbcHmacSha256)
        };
        var Token = TokenHendler.CreateToken(TokenDescription);
        return TokenHendler.WriteToken(Token);
    }

    public bool VerifyToken(string token)
    {
        var JwtSetings = _configuration.GetSection("Jwt");
        var SecretKey = JwtSetings["SecretKey"];
        var SigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        try
        {
            var TokenHendler = new JwtSecurityTokenHandler();
            TokenHendler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = JwtSetings["Issuer"],
                ValidateAudience = true,
                ValidAudience = JwtSetings["Audience"],
                ValidateLifetime = true,
                IssuerSigningKey = SigningKey,
                ValidateIssuerSigningKey = true
            }, out SecurityToken validatedToken);
            return true;
        }
        catch (SecurityTokenException)
        {
            
            return false;
        }
    }
}