using WEB.AUTH.DAL.Interface;
using WEB.AUTH.Domain;
using WEB.AUTH.Domain.DTO;
using WEB.AUTH.Service.Interfaces;

namespace WEB.AUTH.Service.Implementation;

public class UserService : IUserService
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

    public Task<UserEntity> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserEntity> Create(CreatUserDTO creatUserDTO)
    {
        var userEntity = new UserEntity(creatUserDTO);
        return await _userRepository.Creat(userEntity);
    }
    
    public Task<bool> Delete(string id)
    {
        return _userRepository.Delete(id);
    }


    public async Task<UserEntity> Login(LoginDTO loginDto)
    {
       return await _userRepository.Login(loginDto);
    }
}