using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NewFood.Infurstructure.Data.Entities;
using NewsFood.Core.Dto;
using NewsFood.Core.Dto.User;
using NewsFood.Core.Entities;
using NewsFood.Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFood.Infurstructure.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUsers> _userManager;
        private readonly IMapper _mapper;

        public UserRepository(UserManager<AppUsers> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> CheckPassword(User user, string password)
        {
            var appUser = new AppUsers()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName
            };
            //return await _userManager.CheckPasswordAsync(_mapper.Map<AppUsers>(user), password);
            return await _userManager.CheckPasswordAsync(appUser, password);
        }

        public async Task<User> FindbyName(string userName)
        {
            var result = await _userManager.FindByNameAsync(userName);
            return new User(result.Email, result.UserName, result.Id);
        }

        public async Task<CreateUserRespone> Create(User user, string password)
        {
            try
            {
                //var appUser = _mapper.Map<AppUsers>(user);
                var appUser = new AppUsers
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    PasswordHash = user.PasswordHash
                };
                var result = await _userManager.CreateAsync(appUser, password);
                return new CreateUserRespone(appUser.Id, result.Succeeded, result.Succeeded ? null : result.Errors.Select(s => new Error { Code = s.Code, Description = s.Description }));
            }
            catch (Exception ex)
            {

            }
            return null;

        }
    }
}
