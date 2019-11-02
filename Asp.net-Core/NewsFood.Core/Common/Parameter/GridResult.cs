using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Common.Parameter
{
    public class GridResult<T> where T : class
    {
        public int Total { get; set; }
        public IReadOnlyList<T> Items { get; set; }

        public GridResult(IReadOnlyList<T> items, int total)
        {
            Items = items;
            Total = total;
        }
    }
}
