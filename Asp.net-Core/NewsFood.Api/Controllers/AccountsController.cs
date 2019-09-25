using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewFood.Infurstructure.Data.Entities;
using NewsFood.Core.BussinessService;
using NewsFood.Core.Dto;
using NewsFood.Core.Dto.User;
using NewsFood.Core.Entities;
using NewsFood.Core.Interface.Repository;

namespace NewsFood.Api.Controllers
{
    [Authorize]
    public class AccountsController : AppBaseController
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public AccountsController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterAccount([FromBody] RegisterUserDto userDto)
        {
            var result = await _userService.HandleRegisterUser(userDto);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<LoginRespone> Login([FromBody] LoginRequest loginRequest)
        {
            return await _userService.HandleLoginUser(loginRequest);
        }
    }
}