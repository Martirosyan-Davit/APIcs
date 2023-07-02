using WEB.AUTH.Domain;
using WEB.AUTH.Domain.DTO;

namespace WEB.AUTH.Service.Interfaces;

public interface IUserService
{
    Task<UserEntity> Login(LoginDTO loginDto);
    Task<List<UserEntity>> GetAll();
    Task<UserEntity> GetById(string id);
    Task<UserEntity> Create(CreatUserDTO entity);
    Task<bool> Delete(string id);
}