using Microsoft.EntityFrameworkCore;
using WEB.AUTH.DAL.Exceptions;
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
        var users = await _db.User.ToListAsync();
            if(users.Count != 0) return users;
            
            throw new UserNotFoundException();
    }

    public async Task<UserEntity> Creat(UserEntity entity)
    {
            var userEntity = await _db.User.FirstOrDefaultAsync(u => u.Email == entity.Email);
            if (userEntity != null)
            {
                throw new UserAlreadyCreatedException();
            }
            entity.PasswordHash = _passwordHasher.HashPassword(entity.PasswordHash);
            await _db.User.AddAsync(entity);
            await _db.SaveChangesAsync();
            
            return entity;
    }

    public async Task<bool> Delete(string id)
    {
        var userEntity = await _db.User.SingleOrDefaultAsync(u => u.Id == id);

            if (userEntity == null)
            {
                throw new UserNotFoundException();
            }

            _db.User.Remove(userEntity);
            await _db.SaveChangesAsync();

            return true;
    }

   

    public async Task<UserEntity> GetById(string id)
    {
          var userEntity = await _db.User.FindAsync(id);
            if (userEntity == null)
            {
                throw new UserNotFoundException();
            }
            return userEntity;
    }
    
    public async Task<UserEntity> Login(LoginDTO loginDto) 
    {
        var userEntity = await _db.User.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
        if (userEntity == null)
        {
            throw new UserNotFoundException();
        }

        var valid = _passwordHasher.VerifyPassword(loginDto.Password, userEntity.PasswordHash);
        if (!valid)
        {
            throw new IncorrectCredentialsException();
        }

        return userEntity;
    }
}