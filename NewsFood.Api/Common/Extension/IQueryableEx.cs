using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NewsFood.Api.Common.Extension
{
    public static class IQueryableEx
    {
        public static IQueryable<Tsource> WhereIf<Tsource>(this IQueryable<Tsource> source, bool condition, Expression<Func<Tsource, bool>> predicate)
        {
            if (condition)
            {
                source.Where(predicate);
            }
            return source;
        }
    }
}
