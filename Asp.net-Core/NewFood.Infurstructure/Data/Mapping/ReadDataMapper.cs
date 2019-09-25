using NewsFood.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace NewFood.Infurstructure.Data.Mapping
{
    public class ReadDataMapper<TEntity> where TEntity : Entity
    {
        public List<TEntity> MapToList(DbDataReader dr)
        {
            if (dr != null && dr.HasRows)
            {
                var entity = typeof(TEntity);
                var entities = new List<TEntity>();
                var propDict = new Dictionary<string, PropertyInfo>();
                var props = entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                propDict = props.ToDictionary(p => p.Name.ToUpper(), p => p);

                TEntity newObject = default(TEntity);
                while (dr.Read())
                {
                    newObject = Activator.CreateInstance<TEntity>();

                    for (int index = 0; index < dr.FieldCount; index++)
                    {
                        if (propDict.ContainsKey(dr.GetName(index).ToUpper()))
                        {
                            var info = propDict[dr.GetName(index).ToUpper()];
                            if ((info != null) && info.CanWrite)
                            {
                                var val = dr.GetValue(index);
                                info.SetValue(newObject, (val == DBNull.Value) ? null : val, null);
                            }
                        }
                    }

                    entities.Add(newObject);
                }

                return entities;
            }

            return null;
        }
    }
}