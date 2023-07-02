using WEB.AUTH.Domain.DTO;
using WEB.AUTH.Domain.Enum;

namespace WEB.AUTH.Domain;

public class UserEntity : BaseEntity
{
    public  string UserName { get; set; }
    
    public  string Email { get; set; } 
    
    public  string PasswordHash { get; set; }
    
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
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    
    
}