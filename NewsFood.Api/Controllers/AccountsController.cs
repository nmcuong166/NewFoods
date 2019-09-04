using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewFood.Infurstructure.Data.Entities;
using NewsFood.Core.BussinessService;
using NewsFood.Core.Dto.User;
using NewsFood.Core.Interface.Repository;

namespace NewsFood.Api.Controllers
{
    public class AccountsController :  AppBaseController
    {
        private readonly IUserService _userService;

        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterAccount([FromBody] RegisterUserDto userDto)
        {
            var result = await _userService.HandleRegisterUser(userDto);
            if (result)
                return Ok();
            return NotFound();
        }

        [HttpPost("Login")]
        public async Task<bool> Login([FromBody] LoginRequest loginRequest)
        {
            return await _userService.HandleLoginUser(loginRequest);
        }
    }
}