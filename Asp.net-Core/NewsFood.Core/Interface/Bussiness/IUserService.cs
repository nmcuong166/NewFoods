using NewsFood.Core.Dto;
using NewsFood.Core.Dto.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsFood.Core.Interface.Bussiness
{
    public interface IUserService
    {
        Task<CreateUserRespone> HandleRegisterUserAsync(RegisterUserDto user);
        Task<CreateUserRespone> HandleRegisterAdminAsync(RegisterUserDto userDto);
        Task<LoginRespone> HandleLoginAccountAsync(LoginRequest message);
    }
}
