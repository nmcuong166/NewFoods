using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace NewsFood.Core.Common
{
    public static class IQueryableExtension
    {
        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
        {
            if (condition)
            {
                return source.Where(predicate);
            }
            return source;
        }

        public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> source, string propotyName, string value)
        {
            ParameterExpression param = Expression.Parameter(typeof(TSource), "source");

            Expression left = Expression.Property(param, typeof(TSource).GetProperty(propotyName));
            Expression right = ConvertTypeOfStringtoTypeOfPropotyName(propotyName, value, param);
            Expression body = Expression.Equal(left, right);

            var pridicateEx = Expression.Lambda<Func<TSource, bool>>(body, new ParameterExpression[] { param });

            return source.Where(pridicateEx);
        }

        private static UnaryExpression ConvertTypeOfStringtoTypeOfPropotyName(string propertyName, string val, ParameterExpression param)
        {
            var member = Expression.Property(param, propertyName);
            var propertyType = ((PropertyInfo)member.Member).PropertyType;
            var converter = TypeDescriptor.GetConverter(propertyType);

            if (!converter.CanConvertFrom(typeof(string)))
                throw new NotSupportedException();

            var propertyValue = converter.ConvertFromInvariantString(val);
            var constant = Expression.Constant(propertyValue);
            return Expression.Convert(constant, propertyType);
        }
    }
}
