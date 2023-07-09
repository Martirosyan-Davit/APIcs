
using Microsoft.AspNetCore.Http;

namespace WEB.AUTH.DAL.Exceptions;

public class IncorrectCredentialsException : BaseException
{
    protected override string _message => "Invalid Credentials.";
    
    public override int StatusCode => StatusCodes.Status401Unauthorized;
}