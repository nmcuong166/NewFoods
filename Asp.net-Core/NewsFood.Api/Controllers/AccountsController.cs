using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsFood.Api.Presenters;
using NewsFood.Core.Dto;
using NewsFood.Core.Dto.User;
using NewsFood.Core.Interface.Bussiness;
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
        public async Task<ActionResult> RegisterAccountAsync([FromBody] RegisterUserDto userDto)
        {
            var result = await _userService.HandleRegisterUserAsync(userDto);
            return new JsonContentResult<long>(result.Id, result);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("RegisterAdmin")]
        public async Task<ActionResult> RegisterAccountAdminAsync([FromBody] RegisterUserDto userDto)
        {
            var result = await _userService.HandleRegisterAdminAsync(userDto);
            return new JsonContentResult<long>(result.Id, result);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
        {
            var result = await _userService.HandleLoginAccountAsync(loginRequest);
            return new JsonContentResult<Token>(result.Token, result);
        }

    }
}