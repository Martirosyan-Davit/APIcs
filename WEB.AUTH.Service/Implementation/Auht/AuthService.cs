using WEB.AUTH.DAL.Interface;
using WEB.AUTH.Domain;
using WEB.AUTH.Domain.DTO;
using WEB.AUTH.Service.Interfaces;

namespace WEB.AUTH.Service.Implementation;

public class AuthService: IAuthService<UserEntity>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserService<UserEntity> _userService;

    public AuthService(IUserRepository userRepository, 
        IUserService<UserEntity> userService)
    {
        _userRepository = userRepository;
        _userService = userService;
    }


    public Task<UserEntity> RegisterUser(CreatUserDTO creatUserDto)
    {
        var userEntity = new UserEntity(creatUserDto);
        var User = _userService.Create(userEntity);

        return User;
    }

    public async Task<UserEntity> loginUser(LoginDTO loginDto)
    {
        var user = await _userService.Login(loginDto);

        return user;
    }
}