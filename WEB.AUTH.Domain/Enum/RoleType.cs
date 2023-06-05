
using System.ComponentModel.DataAnnotations;

namespace WEB.AUTH.Domain.Enum;

public enum RoleType
{
    [Display(Description= "Administrator")]
    Admin = 1,
    
    [Display(Name= "User")]
    User = 2,
}