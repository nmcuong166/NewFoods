using NewsFood.Core.Common.Untilize;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Common.Parameter
{
    public enum  CacheKey : int
    { 
        [StringValue("CategoriesEntry")]
        CategoriesEntry = 1,
        [StringValue("DemoCache")]
        DemoCache = 2,
    }
}
