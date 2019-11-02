using NewsFood.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsFood.Core.Interface.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : IBaseEntity
    {
        Task<int> InsertAsync(TEntity entity);
        Task<int> DeleteSoft(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
    }
}
