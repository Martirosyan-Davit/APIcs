using System.ComponentModel.DataAnnotations;

namespace WEB.AUTH.Domain.DTO;

public class CreatUserDTO
{
    [Required]
    public string Name { get; set; }  
    [Required]
    public string Email { get;set; }
    
    [Required]
    public string Password { get;set; }
    
}