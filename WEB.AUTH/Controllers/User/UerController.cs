using Microsoft.AspNetCore.Mvc;
using WEB.AUTH.Domain;
using WEB.AUTH.Domain.DTO;
using WEB.AUTH.Service.Interfaces;

namespace WEB.AUTH.Controllers;


    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService<UserEntity> _userService;
        
        public UserController(IUserService<UserEntity> userService)
        {
            _userService = userService;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAll()
        {
            try
            {
                var users = await _userService.GetAll();

                var userDtos = new List<UserDTO>();
                foreach (var user in users)
                {
                    var userDto = new UserDTO(user);
                    userDtos.Add(userDto);
                }

                return Ok(userDtos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                // Return an error response with a meaningful error message
                return StatusCode(StatusCodes
                        .Status500InternalServerError,
                    "Internal server error.");
            }


        }
        
        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetById(Guid id)
        {
            try
            {
                var user = await _userService.GetById(id);
                var userDto = new UserDTO(user);

                return Ok(userDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // Return an error response with a meaningful error message
                return StatusCode(StatusCodes
                        .Status500InternalServerError,
                    "Internal server error.");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Create(CreatUserDTO creatUserDto)
        {
            try
            {
                var userEntity = new UserEntity(creatUserDto);
                var user = await _userService.Create(userEntity);
                var userDto = new UserDTO(user);

                return Ok(userDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // Return an error response with a meaningful error message
                return StatusCode(StatusCodes
                        .Status500InternalServerError,
                    "Internal server error.");
            }
        }



    }
    

    