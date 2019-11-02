using NewsFood.Core.Entities;
using NewsFood.Core.Entities.BaseEntities;
using NewsFood.Core.Interface.BaseEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsFood.Core.Interface.Repository
{
    public interface INewsRepository<TEntity> : IBaseRepository<TEntity> where TEntity : IBaseEntity
    {
        Task<IEnumerable<News>> GetAll();
    }
}
