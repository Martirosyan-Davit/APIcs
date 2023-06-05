using System.Net;
using System.Runtime.CompilerServices;
using WEB.AUTH.DAL.Interface;
using WEB.AUTH.DAL.Repository;
using WEB.AUTH.Domain;
using WEB.AUTH.Domain.DTO;
using WEB.AUTH.Domain.Enum;
using WEB.AUTH.Service.Interfaces;

namespace WEB.AUTH.Service.Implementation;

public class UserService : IService<UserEntity>
{
    
    
    
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public  async Task<List<UserEntity>> GetAll()
    {
        return await _userRepository.Select();
    }
    

    public async Task<UserEntity> GetById(Guid id)
    {
        return await _userRepository.GetById(id);
    }

    public async Task<UserEntity> Create(UserEntity entity)
    {
        
            await _userRepository.Creat(entity);

            return new UserEntity();
    }
    
    public Task<bool> Delete(Guid id)
    {
        return _userRepository.Delete(id);
    }
}