using WEB.AUTH.Domain;
using WEB.AUTH.Domain.DTO;
using WEB.AUTH.Service.Interfaces;

namespace WEB.AUTH.Service.Implementation;

public class AuthService: IAuthService
{
    private readonly IUserService _userService;

    public AuthService(IUserService userService)
    {
        _userService = userService;
    }


    public Task<UserEntity> RegisterUser(CreatUserDTO creatUserDto)
    {

        var User = _userService.Create(creatUserDto);

        return User;
    }

    public async Task<UserEntity> loginUser(LoginDTO loginDto)
    {
        var user = await _userService.Login(loginDto);

        return user;
    }
}