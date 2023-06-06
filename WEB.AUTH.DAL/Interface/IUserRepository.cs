using WEB.AUTH.Domain;
using WEB.AUTH.Domain.DTO;

namespace WEB.AUTH.DAL.Interface;

public interface IUserRepository: IBaseRepository<UserEntity>
{
    Task<UserEntity> GetById(string id);
    Task<UserEntity> Login(LoginDTO loginDto);

}