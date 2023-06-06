using Microsoft.AspNetCore.Mvc;
using WEB.AUTH.Domain;
using WEB.AUTH.Domain.DTO;
using WEB.AUTH.Service.Interfaces;

namespace WEB.AUTH.Controllers;


[ApiController]
[Route("[auth]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService<UserEntity> _authService;

    public AuthController(IAuthService<UserEntity> authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> RegisterUser(CreatUserDTO creatUserDto)
    {
        var user = await _authService.RegisterUser(creatUserDto);

        return Ok(new UserDTO(user));
    }
    
    [HttpPost]
    public async Task<ActionResult<UserDTO>> loginUser(LoginDTO loginDto)
    {
        var user = await _authService.loginUser(loginDto);

        return Ok(new UserDTO(user));
    }
}