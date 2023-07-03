
using System.ComponentModel.DataAnnotations;

namespace WEB.AUTH.Domain.Enum;

public enum RoleType
{
    [Display(Description= "Administrator")]
    ADMIN = 1,
    
    [Display(Name= "User")]
    USER = 2,
}