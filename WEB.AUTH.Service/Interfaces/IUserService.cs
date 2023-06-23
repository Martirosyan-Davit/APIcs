using WEB.AUTH.Domain;
using WEB.AUTH.Domain.DTO;

namespace WEB.AUTH.Service.Interfaces;

public interface IUserService<T>
{
    Task<T> Login(LoginDTO loginDto);
    Task<List<T>> GetAll();
    Task<T> GetById(string id);
    Task<T> Create(CreatUserDTO entity);
    Task<bool> Delete(string id);
    
}