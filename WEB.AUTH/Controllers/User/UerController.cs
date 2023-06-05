using Microsoft.AspNetCore.Mvc;
using WEB.AUTH.Domain;
using WEB.AUTH.Domain.DTO;
using WEB.AUTH.Service.Interfaces;

namespace WEB.AUTH.Controllers;

[ApiController]
[Route("[controller]")]
public class UerController : ControllerBase
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IService<UserEntity> _service;
        

        public UserController(IService<UserEntity> service)
        {
            _service = service;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAll()
        {
            try
            {
                var users = await _service.GetAll();

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
                var user = await _service.GetById(id);
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
        public Task<ActionResult<UserDTO>> Create(CreateDTO createDto)
        {
            try
            {
                var user = await _service.Create(createDto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }



    }
    

}    
    