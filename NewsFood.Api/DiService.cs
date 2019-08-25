using Microsoft.Extensions.DependencyInjection;
using NewFood.Infurstructure.Data.Repository;
using NewsFood.Core;
using NewsFood.Core.BussinessService;
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
            IList<IServiceCollection> list = new List<IServiceCollection>();

            //Infurstructre
            list.Add(services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork)));
            list.Add(services.AddTransient(typeof(IRepository<>), typeof(Repository<>)));
            list.Add(services.AddTransient(typeof(INewsRepository), typeof(NewsRepository)));
            
            //Bussiness Service
            list.Add(services.AddTransient(typeof(INewsService), typeof(NewsService)));
            return list;
        }
    }
}
