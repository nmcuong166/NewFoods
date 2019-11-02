using NewsFood.Core.Common.Parameter;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NewsFood.Core.Common.Extension
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

        public static IQueryable<Tsource> TakePage<Tsource>(this IQueryable<Tsource> query, GridParam gridParam) where Tsource : class
        {
            var newQuery = query;
            if (!string.IsNullOrEmpty(gridParam.Sort))
            {
                newQuery = OrderingHelper(newQuery, gridParam.Sort, gridParam.SortDirection == SortDirection.DESC, false);
            }
            return newQuery.Skip((gridParam.PageNumber - 1) * gridParam.PageSize).Take(gridParam.PageSize);
        }

        //public static async Task<GridResult<T>> GetGridResultAsync<T, Y>(this IQueryable<T> qFullQuery, IQueryable<Y> qTotalQuery, GridParam param) where T : class
        //{
        //    var list = await qFullQuery.TakePage(param).ToListAsync();
        //    var total = await qTotalQuery.CountAsync();
        //    return new GridResult<T>(list, total);
        //}

        public static GridResult<T> GetGridResult<T, Y>(this IQueryable<T> qFullQuery, IQueryable<Y> qTotalQuery, GridParam param) where T : class
        {
            var list = qFullQuery.TakePage(param).ToList();
            var total = qTotalQuery.Count();
            return new GridResult<T>(list, total);
        }

        private static IOrderedQueryable<T> OrderingHelper<T>(IQueryable<T> source, string propertyName, bool descending, bool anotherLevel)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), string.Empty);
            MemberExpression property = Expression.PropertyOrField(param, propertyName);
            LambdaExpression sort = Expression.Lambda(property, param);
            MethodCallExpression call = Expression.Call(
                typeof(Queryable),
                (!anotherLevel ? "OrderBy" : "ThenBy") + (descending ? "Descending" : string.Empty),
                new[] { typeof(T), property.Type },
                source.Expression,
                Expression.Quote(sort));
            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
        }
    }
}
