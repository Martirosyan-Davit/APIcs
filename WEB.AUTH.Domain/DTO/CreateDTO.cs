using System.ComponentModel.DataAnnotations;

namespace WEB.AUTH.Domain.DTO;

public class CreateDTO
{
    [Required]
    public string Email { get;set; }
    
    [Required]
    public string Password { get;set; }
}