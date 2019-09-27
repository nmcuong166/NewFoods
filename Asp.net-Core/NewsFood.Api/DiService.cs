using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NewFood.Infurstructure.Auth;
using NewFood.Infurstructure.Data;
using NewFood.Infurstructure.Data.Entities;
using NewFood.Infurstructure.Data.Repository;
using NewsFood.Core;
using NewsFood.Core.BussinessService;
using NewsFood.Core.Interface.Auth;
using NewsFood.Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFood.Api
{
    public static class DiService
    {
        public static IList<IServiceCollection> DIServiceExtension(this IServiceCollection services)
        {
            IList<IServiceCollection> list = new List<IServiceCollection>
            {
                //Infurstructre
                services.AddTransient(typeof(UserManager<AppUsers>)),
                services.AddTransient(typeof(RoleManager<AppRoles>)),
                services.AddTransient(typeof(IJWTFactory), typeof(JWTFactory)),
                services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork)),
                services.AddTransient(typeof(IRepository<>), typeof(Repository<>)),
                services.AddTransient(typeof(MyIdentityDataInitializer)),
                services.AddTransient(typeof(INewsRepository), typeof(NewsRepository)),
                services.AddTransient(typeof(IUserRepository), typeof(UserRepository)),

                //Bussiness Service
                services.AddTransient(typeof(INewsService), typeof(NewsService)),
                services.AddTransient(typeof(IUserService), typeof(UserService))
            };
            return list;
        }
    }
}
