using System.ComponentModel.DataAnnotations;

namespace WEB.AUTH.Domain.DTO;

public class LoginDTO
{
   
    [Required]
    public string Email { get;set; }
    
    [Required]
    public string Password { get;set; }
}