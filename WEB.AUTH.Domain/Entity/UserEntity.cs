using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using WEB.AUTH.Domain.DTO;
using WEB.AUTH.Domain.Enum;

namespace WEB.AUTH.Domain;

public class UserEntity : BaseEntity
{
    
    public override string UserName { get; set; }
    public override string Email { get; set; } 
    
    public override string PasswordHash { get; set; }
    
    // public RoleType Role { get; set; }
    
    public UserEntity() {}
    
    
    public UserEntity(UserDTO userDto)
    {
        UserName = userDto.UserName;
        Email = userDto.Email;
        Id = userDto.Id;
    }
    
    public UserEntity(CreatUserDTO createDto)
    {
        UserName = createDto.Name;
        Email = createDto.Email;
        PasswordHash = createDto.Password;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
    
    
    
}