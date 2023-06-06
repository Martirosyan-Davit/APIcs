using System.Net;
using WEB.AUTH.Domain.Enum;

namespace WEB.AUTH.Domain.DTO;

public class UserDTO
{
        public string Id { get; set; } 
        public string UserName { get; set; }
        public string Email { get; set; }
        
        public UserDTO(UserEntity userEntity)
        {
                this.Id = userEntity.Id;
                this.UserName = userEntity.UserName;
                this.Email = userEntity.Email;
        }
}