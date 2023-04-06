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
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("signup")]
        public IActionResult Signup(UserForRegisterDto userForRegisterDto)
        {
            var registerResult = _authService.Register(userForRegisterDto);
            if(!registerResult.Success)
                return BadRequest(registerResult.Message);
                
            var result = _authService.CreateAccessToken(registerResult.Data);
            if(result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    
        [HttpPost("signin")]
        public IActionResult Signin(UserForLoginDto userForLoginDto)
        {
            var loginResult = _authService.Login(userForLoginDto);
            if(!loginResult.Success)
                return BadRequest(loginResult.Message);
            
            var result = _authService.CreateAccessToken(loginResult.Data);
            return result.Success ? Ok(result) :BadRequest(result);
        }
    }
}