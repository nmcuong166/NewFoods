using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NewsFood.Core.Common
{
    public static class IQueryableExtension
    {
        public static IQueryable<TEntity> WhereIf<TEntity>(this IQueryable<TEntity> source, bool condition, Expression<Func<TEntity, bool>> predicate)
        {
            if (condition)
            {
                return source.Where(predicate);
            }
            return source;
        }
    }
}
