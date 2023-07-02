using WEB.AUTH.Domain;
using WEB.AUTH.Domain.DTO;

namespace WEB.AUTH.Service.Interfaces;

public interface IAuthService
{
    Task<UserEntity> RegisterUser(CreatUserDTO creatUserDto);
    
    Task<UserEntity> loginUser(LoginDTO loginDto);
}