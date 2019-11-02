using NewsFood.Core.Common.Constant;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Common.Parameter
{
    public class GridParam
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = ConstantDefine.DEFAULT_PAGESIZE;
        public string SearchKeyWord { get; set; }
        public string Sort { get; set; }
        public SortDirection SortDirection { get; set; }
        public IEnumerable<SearchItem> SearchItems { get; set; }
    }

    public class SearchItem
    {
        public string SearchTerm { get; set; }
        public string SearchProperty { get; set; }
        public bool IsMatch { get; set; }
    }
}
