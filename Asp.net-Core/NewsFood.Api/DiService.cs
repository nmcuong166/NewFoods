using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NewFood.Infurstructure.Auth;
using NewFood.Infurstructure.Data;
using NewFood.Infurstructure.Data.Entities;
using NewFood.Infurstructure.Data.Repository;
using NewsFood.Core.BusinessServices;
using NewsFood.Core.Interface.Auth;
using NewsFood.Core.Interface.Bussiness;
using NewsFood.Core.Interface.Repository;
using System.Collections.Generic;

namespace NewsFood.Api
{
    public static class DiService
    {
        public static IList<IServiceCollection> DIServiceExtension(this IServiceCollection services)
        {
            IList<IServiceCollection> listRegisterDI = new List<IServiceCollection>
            {
                //Infurstructre
                services.AddSingleton(typeof(IUnitOfWork), typeof(UnitOfWork)),
                services.AddScoped(typeof(UserManager<AppUsers>)),
                services.AddScoped(typeof(RoleManager<AppRoles>)),
                services.AddTransient(typeof(IJWTFactory), typeof(JWTFactory)),
                services.AddTransient(typeof(MyIdentityDataInitializer)),
                services.AddTransient(typeof(INewsRepository<>), typeof(NewsRepository<>)),
                services.AddTransient(typeof(IUserRepository), typeof(UserRepository)),
                services.AddTransient(typeof(ICategoriesRepository<>), typeof(CategoriesRepository<>)),

                //Bussiness Service
                services.AddTransient(typeof(INewsService), typeof(NewsService)),
                services.AddTransient(typeof(IUserService), typeof(UserService)),
                services.AddTransient(typeof(ICategoriesService), typeof(CategoriesService))
            };
            return listRegisterDI;
        }
    }
}
