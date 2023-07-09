using WEB.AUTH.Domain.DTO;

namespace WEB.AUTH.Domain;

public class LoginPayloadDTO
{
    public UserDTO UserDto { get; set; }
    public string Token { get; set; }

    public LoginPayloadDTO(UserDTO userDto, string token)
    {
        UserDto = userDto;
        Token = token;
    }
}