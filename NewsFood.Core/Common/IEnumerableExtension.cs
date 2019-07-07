using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Common
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<TEntity> WhereIf<TEntity>(this IEnumerable<TEntity> source, bool condition, Func<TEntity,bool> predicate)
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
