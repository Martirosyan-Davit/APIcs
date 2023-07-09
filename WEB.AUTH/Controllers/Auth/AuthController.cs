using Microsoft.AspNetCore.Mvc;
using WEB.AUTH.Domain;
using WEB.AUTH.Domain.DTO;
using WEB.AUTH.Service.Interfaces;

namespace WEB.AUTH.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    
    [HttpPost("Register")]
    public async Task<ActionResult<LoginPayloadDTO>> RegisterUser(CreatUserDTO creatUserDto)
    {
        var user = await _authService
            .RegisterUser(creatUserDto);
        
        return Ok(user);
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<LoginPayloadDTO>> loginUser(LoginDTO loginDto)
    {
        var user = await _authService
            .loginUser(loginDto);
        
        return Ok(user);
    }
}