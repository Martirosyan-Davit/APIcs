using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WEB.AUTH.Domain;

public abstract class BaseEntity: IdentityUser
{
    [Key]
    public override string Id { get; set; }
    [Column]
    public DateTime CreatedAt { get; set; }
    [Column]
    public DateTime UpdatedAt { get; set; }

    
}