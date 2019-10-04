using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFood.Core.Common.Extension
{
    public static class IEnumerableEx
    {
        public static IEnumerable<Tsource> WhereIf<Tsource>(this IEnumerable<Tsource> source, bool condition, Func<Tsource,bool> predicate)
        {
            if (condition)
            {
                source.Where(predicate);
            }
            return source;
        }

        public static bool IsNullOrEmpty<Tsource>(this IEnumerable<Tsource> sources)
        {
            return sources == null || !sources.Any();
        }
    }
}
