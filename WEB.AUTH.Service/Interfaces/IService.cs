using WEB.AUTH.Domain;
using WEB.AUTH.Domain.DTO;

namespace WEB.AUTH.Service.Interfaces;

public interface IService<T>
{
    Task<List<T>> GetAll();
    Task<T> GetById(Guid id);
    Task<T> Create(T entity);
    Task<bool> Delete(Guid id);
    
}