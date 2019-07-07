using Microsoft.Extensions.DependencyInjection;
using NewsFood.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFood.Application
{
    /// <summary>
    /// Add DI Service Application
    /// </summary>
    public static class DIService
    {
        public static IList<IServiceCollection> DIServiceExtension(this IServiceCollection services)
        {
            IList<IServiceCollection> list = new List<IServiceCollection>();
            list.Add(services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork)));
            return list;
        }
    }
}
