using System.Net;
using WEB.AUTH.Domain.Enum;

namespace WEB.AUTH.Domain.DTO;

public class UserDTO: UserEntity
{
        public UserDTO(UserEntity userEntity)
        {
                this.Id = userEntity.Id;
                this.Name = userEntity.Name;
                this.Email = userEntity.Email;
                this.Role = userEntity.Role;
        }
}