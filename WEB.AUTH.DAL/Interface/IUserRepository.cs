using WEB.AUTH.Domain;

namespace WEB.AUTH.DAL.Interface;

public interface IUserRepository: IBaseRepository<UserEntity>
{
    Task<UserEntity> GetById(Guid id);
    
}