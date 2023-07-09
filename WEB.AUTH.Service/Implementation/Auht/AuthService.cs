using WEB.AUTH.Domain;
using WEB.AUTH.Domain.DTO;
using WEB.AUTH.Managers.Authorization.Intrfaces;
using WEB.AUTH.Service.Interfaces;

namespace WEB.AUTH.Service.Implementation;

public class AuthService: IAuthService
{
    private readonly IUserService _userService;
    private readonly IAuthorizationManager _authorizationManager;

    public AuthService(IUserService userService, IAuthorizationManager authorizationManager)
    {
        _userService = userService;
        _authorizationManager = authorizationManager;
    }


    public async Task<LoginPayloadDTO> RegisterUser(CreatUserDTO creatUserDto)
    {
        var User = await _userService.Create(creatUserDto);
        string Token = _authorizationManager.GenerateToken(User.Id);
        var CorrentUser = new UserDTO(User);

        return new LoginPayloadDTO(CorrentUser, Token);
    }
    public async Task<LoginPayloadDTO> loginUser(LoginDTO loginDto)
    {
        var user = await _userService.Login(loginDto);
        string Token = _authorizationManager.GenerateToken(user.Id);
        var CurrentUser = new UserDTO(user);

        return new LoginPayloadDTO(CurrentUser, Token);
    }
}