
using Microsoft.AspNetCore.Identity;
using WEB.AUTH.Domain.Helper;

namespace WEB.AUTH.Domain;

public abstract class BaseEntity : EntityHelper
{
    public override string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    
}