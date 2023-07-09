using WEB.AUTH.Domain;
using WEB.AUTH.Domain.DTO;

namespace WEB.AUTH.Service.Interfaces;

public interface IAuthService
{
    Task<LoginPayloadDTO> RegisterUser(CreatUserDTO creatUserDto);
    
    Task<LoginPayloadDTO> loginUser(LoginDTO loginDto);
}