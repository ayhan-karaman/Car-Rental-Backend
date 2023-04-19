using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApiUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-user")]
        public IActionResult GetByEmailUserDetail(string email_or_username)
        {
              var result = _userService.GetByEmailUserDetailDto(email_or_username);
              
              return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update-user")]
        public IActionResult UpdateProfile([FromForm] UserForUpdateDto userForUpdateDto)
        {
              var result = _userService.UpdateUserProfile(userForUpdateDto);
              
              return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update-password")]
        public IActionResult UpdatePassword(UpdateUserPasswordDto updateUserPassword)
        {
              var result = _userService.UpdateUserPassword(updateUserPassword);
              
              return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}