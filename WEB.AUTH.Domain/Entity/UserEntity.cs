using System.ComponentModel.DataAnnotations.Schema;
using WEB.AUTH.Domain.DTO;
using WEB.AUTH.Domain.Enum;

namespace WEB.AUTH.Domain;

[Table("user")]
public class UserEntity : BaseEntity
{
    [Column]
    public override string UserName { get; set; }
    [Column]
    public override string Email { get; set; } 
    [Column]
    public override string PasswordHash { get; set; }
    [Column]
    public RoleType Role { get; set; }
    
    // One-to-many relationship with posts
    public List<PostEntity>? Posts { get; set; }
    
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