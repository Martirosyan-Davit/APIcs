using System.ComponentModel.DataAnnotations;
using WEB.AUTH.Domain.DTO;
using WEB.AUTH.Domain.Enum;

namespace WEB.AUTH.Domain;

public class UserEntity : BaseEntity
{
    
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    
    public RoleType Role { get; set; }
    
    public UserEntity() {}


    public UserEntity(UserDTO userDto)
    {
        this.Email = userDto.Email;
        this.Password = userDto.Password;
    }
    
    
}