﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NewsFood.Infurstructure.Auth;
using NewsFood.Infurstructure.Data;
using NewsFood.Infurstructure.Data.Entities;
using NewsFood.Infurstructure.Data.Repository;
using NewsFood.Core.BusinessServices;
using NewsFood.Core.Interface.Auth;
using NewsFood.Core.Interface.Bussiness;
using NewsFood.Core.Interface.Repository;
using System.Collections.Generic;
using NewsFood.Core.Interface.Services;

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
                services.AddTransient(typeof(ICategoriesService), typeof(CategoriesService)),
                services.AddTransient(typeof(IInmemoryCacheService), typeof(InMemoryCacheService))
            };
            return listRegisterDI;
        }
    }
}
