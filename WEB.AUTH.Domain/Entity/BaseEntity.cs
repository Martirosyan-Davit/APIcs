using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WEB.AUTH.Domain;

public abstract class BaseEntity: IdentityUser
{
    [Key]
    public override string Id { get; set; }

    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}