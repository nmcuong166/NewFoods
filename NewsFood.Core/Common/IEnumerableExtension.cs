using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NewsFood.Core.Common
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource,bool> predicate)
        {
            foreach (var item in source)
            {
                if(condition && predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
