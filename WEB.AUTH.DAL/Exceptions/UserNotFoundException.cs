using Microsoft.AspNetCore.Http;

namespace WEB.AUTH.DAL.Exceptions;

public class UserNotFoundException : BaseException
{
    protected override string _message => "User not found.";
    
    public override int StatusCode => StatusCodes.Status404NotFound;

    
}