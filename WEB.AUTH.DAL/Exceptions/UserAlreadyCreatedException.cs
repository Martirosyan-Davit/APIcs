using Microsoft.AspNetCore.Http;

namespace WEB.AUTH.DAL.Exceptions;

public class UserAlreadyCreatedException : BaseException
{
    protected override string _message => "User already created.";
    
    public override int StatusCode => StatusCodes.Status409Conflict;

    
}