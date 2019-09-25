using NewsFood.Core.Dto.User;
using NewsFood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsFood.Core.Interface.Repository
{
    public interface IUserRepository
    {
        Task<CreateUserRespone> Create(User user, string password);
        Task<User> FindbyName(string userName);
        Task<bool> CheckPassword(User user, string password);
    }
}
