using AutoMapper;
using NewFood.Infurstructure.Data.Entities;
using NewsFood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewFood.Infurstructure.Data.Mapping
{
    public class DataProfiles : Profile
    {
        public DataProfiles()
        {
            CreateMap<User, AppUsers>().ConstructUsing(u => new AppUsers { Id = u.Id, Email = u.Email, UserName = u.UserName, PasswordHash = u.PasswordHash });
            CreateMap<AppUsers, User>().ConstructUsing(au => new User(au.Email, au.UserName, au.Id, au.PasswordHash));
        }
    }
}
