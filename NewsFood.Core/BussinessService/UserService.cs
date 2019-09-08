using NewsFood.Core.Dto;
using NewsFood.Core.Dto.User;
using NewsFood.Core.Interface.Auth;
using NewsFood.Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsFood.Core.BussinessService
{
    public interface IUserService
    {
        Task<bool> HandleRegisterUser(RegisterUserDto user);
        Task<LoginRespone> HandleLoginUser(LoginRequest message);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTFactory _jwtFactory;
        public UserService(IUserRepository userRepository, IJWTFactory jwtFactory)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
        }

        public async Task<bool> HandleRegisterUser(RegisterUserDto user)
        {
            var result = await _userRepository.Create(new Entities.User(user.Email, user.UserName), user.Password);
            return result.Success;
        }

        public async Task<LoginRespone> HandleLoginUser(LoginRequest message)
        {
            var user = await _userRepository.FindbyName(message.UserName);
            if(user != null)
            {
                var isVaild = await _userRepository.CheckPassword(user, message.PassWord);
                if (isVaild)
                {
                    var token = await _jwtFactory.GenerateToken(user.Id, user.UserName);
                    return new LoginRespone(token, true);
                }
            }
            return new LoginRespone(null, false);
        }
    }
}
