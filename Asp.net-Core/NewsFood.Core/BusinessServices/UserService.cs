using NewsFood.Core.Common.Language;
using NewsFood.Core.Dto;
using NewsFood.Core.Dto.User;
using NewsFood.Core.Entities;
using NewsFood.Core.Interface.Auth;
using NewsFood.Core.Interface.Bussiness;
using NewsFood.Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NewsFood.Core.BusinessServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTFactory _jwtFactory;
        public UserService(IUserRepository userRepository, IJWTFactory jwtFactory)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
        }

        public async Task<CreateUserRespone> HandleRegisterUserAsync(RegisterUserDto userDto)
        {
            var resultUser = await _userRepository.Create(new User(userDto.Email, userDto.UserName), userDto.Password);
            if (resultUser.Success)
            {
                var claim = new Claim(ClaimTypes.Role, "User");
                var rsClaims = await _userRepository.InsertClaims(new User(userDto.Email, userDto.UserName), claim);
                return new CreateUserRespone(resultUser.Id, resultUser.Success);
            }
            return new CreateUserRespone(resultUser.Id, resultUser.Success, resultUser.Errors);
        }

        public async Task<CreateUserRespone> HandleRegisterAdminAsync(RegisterUserDto userDto)
        {
            var user = new User(userDto.Email, userDto.UserName);
            var resultUser = await _userRepository.Create(user, userDto.Password);
            if (resultUser.Success)
            {
                var claim = new Claim(ClaimTypes.Role, "Admin");
                var rsClaims = await _userRepository.InsertClaims(user, claim);
            }
            return new CreateUserRespone(resultUser.Id, resultUser.Success, resultUser.Errors);
        }

        public async Task<LoginRespone> HandleLoginAccountAsync(LoginRequest message)
        {
            var user = await _userRepository.FindbyName(message.UserName);
            if (user != null)
            {
                var isVaild = await _userRepository.CheckPassword(user, message.PassWord);
                if (isVaild)
                {
                    var claims = await _userRepository.GetUserClaims(user);
                    var token = await _jwtFactory.GenerateToken(user.Id, user.UserName, claims);
                    return new LoginRespone(token, true);
                }
                return new LoginRespone(new List<Error> { ErrorMessage.GetErrorInvaildMessage() }, null);
            }
            return new LoginRespone(new List<Error> { ErrorMessage.GetErrorInvaildMessage() }, null);
        }
    }
}
