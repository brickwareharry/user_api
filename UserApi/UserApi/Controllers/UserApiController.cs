using Microsoft.AspNetCore.Mvc;
using UserApi.Data;
using UserApi.Models;
using UserApi.Models.Dto;

namespace UserApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/users")]
    [ApiController]
    public class UserApiController:ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] //or use [ProducesResponseType(200)]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            return Ok(UserStore.userList);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)] //or use [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //or use [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //or use [ProducesResponseType(404)]
        public ActionResult<UserDto> GetUser(int id)
        {
            if (id == 0) 
            { 
                return BadRequest(); 
            };
            var user = UserStore.userList.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}

