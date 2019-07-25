using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace NewsFood.Core.Common.ProcedureHelper
{
    public static class SqlDataReaderExtension
    {
        /// <summary>
        /// Maps to list.
        /// </summary>
        /// <typeparam name="Type"></typeparam>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        public static List<Type> MapperToList<Type>(this IDataReader reader)
        {
            List<Type> list = new List<Type>();
            while (reader.Read())
            {
                if (typeof(Type) == typeof(string))
                {
                    list.Add(reader.GetString(0).Parse<Type>());
                }
                else
                {
                    Type instance = Activator.CreateInstance<Type>();
                    if (instance.GetType().GetProperties().Length == 0)
                    {
                        list.Add(reader.GetInt32(0).Parse<Type>());
                    }
                    else
                    {
                        foreach (PropertyInfo prop in instance.GetType().GetProperties())
                        {
                            if (reader.HasColumn(prop.Name))
                            {
                                if (!Equals(reader[prop.Name], DBNull.Value))
                                {
                                    prop.SetValue(instance, reader[prop.Name], null);
                                }
                            }
                        }

                        list.Add(instance);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Determines whether the specified column name has column.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="sColumnName">Name of the column.</param>
        /// <returns></returns>
        public static bool HasColumn(this IDataRecord reader, string sColumnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(sColumnName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <typeparam name="Type"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Type Parse<Type>(this Object value)
        {
            if (value == null || value is DBNull) return default(Type);
            if (value is Type) return (Type)value;
            System.Type type = typeof(Type);
            type = Nullable.GetUnderlyingType(type) ?? type;
            if (type.IsEnum)
            {
                if (value is float || value is double || value is decimal)
                {
                    value = Convert.ChangeType(value, Enum.GetUnderlyingType(type), CultureInfo.InvariantCulture);
                }
                return (Type)Enum.ToObject(type, value);
            }
            return (Type)Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
        }
    }
}
