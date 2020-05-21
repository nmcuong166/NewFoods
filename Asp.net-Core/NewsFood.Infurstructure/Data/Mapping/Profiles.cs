using AutoMapper;
using NewsFood.Infurstructure.Data.Entities;
using NewsFood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Infurstructure.Data.Mapping
{
    public class DataProfiles : Profile
    {
        public DataProfiles()
        {
            CreateMap<User, AppUsers>().ConstructUsing(u => new AppUsers { Email = u.Email, UserName = u.UserName, PasswordHash = u.PasswordHash, SecurityStamp = u.SecurityStamp });
            CreateMap<AppUsers, User>().ConstructUsing(au => new User { Email =  au.Email, UserName =  au.UserName, Id =  au.Id, PasswordHash = au.PasswordHash, SecurityStamp = au.SecurityStamp });
        }
    }
}
