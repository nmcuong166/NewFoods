using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NewFood.Infurstructure.Data.Entities;
using NewsFood.Core.Dto;
using NewsFood.Core.Dto.BussinessService;
using NewsFood.Core.Dto.User;
using NewsFood.Core.Entities;
using NewsFood.Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            var appUser = _mapper.Map<AppUsers>(user);
            var rs = await _userManager.CheckPasswordAsync(appUser, password);
            return rs;
        }

        public async Task<User> FindbyName(string userName)
        {
            var result = await _userManager.FindByNameAsync(userName);
            var user = _mapper.Map<User>(result);
            return user;
        }

        public async Task<CreateUserRespone> Create(User user, string password)
        {
            var appUser = _mapper.Map<AppUsers>(user);
            var result = await _userManager.CreateAsync(appUser, password);
            return new CreateUserRespone(appUser.Id, result.Succeeded, result.Succeeded ? null : result.Errors.Select(s => new Error { Code = s.Code, Description = s.Description }));
        }

        public async Task<List<Claim>> GetUserClaims(User user)
        {
            var appUser = _mapper.Map<AppUsers>(user);
            var result = await _userManager.GetClaimsAsync(appUser);
            return result.ToList();
        }

        public async Task<CreateUserRespone> InsertClaims(User user, Claim claim)
        {
            var username = user.UserName;
            var userById = await _userManager.FindByNameAsync(user.UserName);
            var result = await _userManager.AddClaimAsync(userById, claim);
            return new CreateUserRespone(userById.Id, result.Succeeded, result.Succeeded ? null : result.Errors.Select(s => new Error { Code = s.Code, Description = s.Description }));
        }
    }
}
