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
        public IEnumerable<UserDto> GetUsers()
        {
            return UserStore.userList;
        }

        [HttpGet("{id:int}")]
        public UserDto GetUsers(int id)
        {
            return UserStore.userList.FirstOrDefault(u=>u.Id==id);
        }
    }
}

