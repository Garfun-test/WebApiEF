﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiEF.DAL.Identity;
using WebApiEF.BLL.Interface;

namespace WebApiEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterUser user)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(user);

                if (result.IsSuccess)
                    return Ok(result); //Status code: 200

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid"); //Status code: 400
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginUser user)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(user);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
                
            }

            return BadRequest("Some properties are not valid");
        }
    }
}