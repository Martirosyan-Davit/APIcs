using WEB.AUTH.Domain.DTO;

namespace WEB.AUTH.Service.Interfaces;

public interface IAuthService<T>
{
    Task<T> RegisterUser(CreatUserDTO creatUserDto);
    
    Task<T> loginUser(LoginDTO loginDto);
}