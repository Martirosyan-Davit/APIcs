using Microsoft.EntityFrameworkCore;
using WEB.AUTH.DAL.Helper;
using WEB.AUTH.DAL.Interface;
using WEB.AUTH.Domain;
using WEB.AUTH.Domain.DTO;

namespace WEB.AUTH.DAL.Repository;

public class UserRepository: IUserRepository
{
    private readonly ApplicationDbContext _db;
    private readonly PasswordHasher _passwordHasher;

    public UserRepository(ApplicationDbContext db)
    {
        _db = db; 
        _passwordHasher = new PasswordHasher();
    }

    public async Task<List<UserEntity>> Select()
    {
        try
        {
            var users = await _db.User.ToListAsync();
            if(users.Count != 0) return users;
            
            throw new Exception("Users not found.");
            
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw new Exception(ex.Message);
        }
    }

    public async Task<UserEntity> Creat(UserEntity entity)
    {
        try
        {
            var userEntity = await _db.User.FirstOrDefaultAsync(u => u.Email == entity.Email);
            if (userEntity != null)
            {
                throw new Exception("User already created.");
            }
            
            entity.PasswordHash = _passwordHasher.HashPassword(entity.PasswordHash);

            await _db.User.AddAsync(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
        catch (Exception ex)
        {
            
            Console.WriteLine(ex);
            throw new Exception(ex.Message);

        }
    }

    public async Task<bool> Delete(string id)
    {
        try
        {
            var userEntity = await _db.User.SingleOrDefaultAsync(u => u.Id == id);

            if (userEntity == null)
            {
                throw new Exception("User not found.");
            }

            _db.User.Remove(userEntity);
            await _db.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            
            Console.WriteLine(ex);
            throw new Exception(ex.Message);
        }
    }

   

    public async Task<UserEntity> GetById(string id)
    {
        try
        {
            var userEntity = await _db.User.FindAsync(id);
            if (userEntity == null)
            {
                throw new Exception("User not found.");
            }

            return userEntity;
        }
        catch (Exception ex)
        {
            
            Console.WriteLine(ex);
            throw new Exception(ex.Message);
        }
    }
    public async Task<UserEntity> Login(LoginDTO loginDto) 
    {
        var userEntity = await _db.User.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
        if (userEntity == null)
        {
            throw new Exception("User not found.");
        }

        var valid = _passwordHasher.VerifyPassword(loginDto.Password, userEntity.PasswordHash);
        if (!valid)
        {
            throw new Exception("Email or password incorrect.");
        }

        return userEntity;
    }
}