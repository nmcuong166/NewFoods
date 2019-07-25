using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Common.ProcedureHelper
{
    public class DatabaseResponseData<Type>
    {
        /// <summary>
        /// Response Status after it completely query data from database
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Response Message after it completely query data from database
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Response Data after it completely query data from database
        /// </summary>
        public Type Data { get; set; }
    }
}
