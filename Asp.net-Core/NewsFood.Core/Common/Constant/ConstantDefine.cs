using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Common.Constant
{
    public class ConstantDefine
    {
        public static readonly int DEFAULT_PAGESIZE = 10;
    }

    public enum Level : byte
    {
        Low = 0,
        Normal = 1,
        High = 2
    }
}
