using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace NewsFood.Core.Common.ProcedureHelper
{
    public interface IProcHelper
    {
        Task<DatabaseResponseData<IList<Type>>> ExecuteQueryAsync<Type>(string sQuery, object param, CommandType commandType, string tableType = null);
    }
}
