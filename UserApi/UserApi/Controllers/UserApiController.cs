﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using UserApi.Data;
using UserApi.Models;
using UserApi.Models.Dto;

namespace UserApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/users")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] //or use [ProducesResponseType(200)]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            return Ok(UserStore.userList);
        }

        [HttpGet("{id:int}", Name = "GetTheUser")]
        [ProducesResponseType(StatusCodes.Status200OK)] //or use [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //or use [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //or use [ProducesResponseType(404)]
        public ActionResult<UserDto> GetUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            };
            var exUser = UserStore.userList.FirstOrDefault(u => u.Id == id);
            if (exUser == null)
            {
                return NotFound();
            }
            return Ok(exUser);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UserDto> CreateUser([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest(userDto);
            }
            if (userDto.Id != 0)
            {
                return BadRequest(userDto);
            }
            //TODO: validate if email format is correct or not
            //User's email have to be unique
            if (UserStore.userList.FirstOrDefault(u => u.Email.ToLower() == userDto.Email.ToLower()) != null)
            {
                ModelState.AddModelError("UserEmailValidationError", "User's email already exists");
                return BadRequest(ModelState);
            }
            var lastUser = UserStore.userList.OrderByDescending(u => u.Id).FirstOrDefault();
            if (lastUser != null)
            {
                userDto.Id = lastUser.Id + 1;
            }
            else
            {
                userDto.Id = 1;
            }
            UserStore.userList.Add(userDto);
            return CreatedAtRoute("GetTheUser", new { id = userDto.Id }, userDto);
        }

        [HttpDelete("{id:int}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteUser(int id) 
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var exUser = UserStore.userList.FirstOrDefault(u => u.Id == id);
            if (exUser == null)
            {
                return NotFound();
            }
            UserStore.userList.Remove(exUser);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateUser(int id, [FromBody] UserDto userDto)
        {
            if (userDto == null || id != userDto.Id)
            {
                return BadRequest();
            }
            var exUser = UserStore.userList.FirstOrDefault(u => u.Id == id);
            if (exUser == null)
            {
                return NotFound();
            }
            exUser.FirstName = userDto.FirstName;
            exUser.LastName = userDto.LastName;
            exUser.Email = userDto.Email;
            return NoContent();
        }
    }
}

