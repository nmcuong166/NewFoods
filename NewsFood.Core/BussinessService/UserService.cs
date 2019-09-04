using NewsFood.Core.Dto.User;
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
        Task<bool> HandleLoginUser(LoginRequest message);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> HandleRegisterUser(RegisterUserDto user)
        {
            var result = await _userRepository.Create(new Entities.User(user.Email, user.UserName), user.Password);
            return result.Success;
        }

        public async Task<bool> HandleLoginUser(LoginRequest message)
        {
            var user = await _userRepository.FindbyName(message.UserName);
            if(user != null)
            {
                var isVaild = await _userRepository.CheckPassword(user, message.PassWord);
                if (isVaild)
                    return true;
                return false;
            }
            return false;
        }
    }
}
