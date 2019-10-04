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
using NewsFood.Core.Interface.Bussiness;
using NewsFood.Core.Interface.Repository;

namespace NewsFood.Api.Controllers
{
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
            var result = await _userService.HandleRegisterUserAsync(userDto);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("RegisterAdmin")]
        public async Task<ActionResult> RegisterAccountAdmin([FromBody] RegisterUserDto userDto)
        {
            var result = await _userService.HandleRegisterAdminAsync(userDto);
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
            return await _userService.HandleLoginAccountAsync(loginRequest);
        }
    }
}