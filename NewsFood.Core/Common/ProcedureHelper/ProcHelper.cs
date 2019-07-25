using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NewsFood.Core.Common.ProcedureHelper
{
    public class ProcHelper : IProcHelper
    {
        private readonly string _sConnectString;

        public ProcHelper(IConfiguration configuration)
        {
            _sConnectString = configuration["Data:NewsFood:ConnectionString"];
        }

        public async Task<DatabaseResponseData<IList<Type>>> ExecuteQueryAsync<Type>(string sQuery, object param, CommandType commandType, string tableType = null)
        {
            if (string.IsNullOrEmpty(sQuery))
            {
                throw new ArgumentNullException(nameof(sQuery));
            }

            using (SqlConnection connection = new SqlConnection(_sConnectString))
            using (SqlCommand command = new SqlCommand(sQuery, connection))
            {
                DatabaseResponseData<IList<Type>> response = new DatabaseResponseData<IList<Type>>();
                try
                {
                    connection.Open();
                    command.CommandType = commandType;

                    if (param != null)
                    {
                        foreach (PropertyInfo p in param.GetType().GetProperties())
                        {
                            object val = p.GetValue(param, null);
                            string key = $"@{p.Name}";
                            object value = (val == null || val.ToString().Length == 0) ? DBNull.Value : val;
                            if (val != null)
                            {
                                if (val.GetType().Name == "DataTable" && !string.IsNullOrEmpty(tableType))
                                {
                                    value = val;
                                    SqlParameter sqlParam = command.Parameters.AddWithValue(key, value);
                                    sqlParam.SqlDbType = SqlDbType.Structured;
                                    sqlParam.TypeName = tableType;
                                }
                                else
                                {
                                    command.Parameters.AddWithValue(key, value);
                                }
                            }
                            else
                            {
                                command.Parameters.AddWithValue(key, value);
                            }
                        }
                    }

                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    List<Type> instanse = reader.MapperToList<Type>();

                    reader.Dispose();
                    reader.Close();

                    response.Success = true;
                    response.Data = instanse;
                }
                catch (Exception exception)
                {
                    response.Success = false;
                    response.Message = exception.Message;
                    response.Data = null;
                }
                finally
                {
                    command.Dispose();
                    connection.Dispose();
                    connection.Close();
                }
                return response;
            }
        }

    }
}