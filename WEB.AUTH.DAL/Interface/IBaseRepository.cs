using WEB.AUTH.Domain;

namespace WEB.AUTH.DAL.Interface;

public interface IBaseRepository<T>
{
    Task<List<T>> Select();
    
    Task<T> Creat(T entity);
    
    Task<bool> Delete(string id);
}