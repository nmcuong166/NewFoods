using NewsFood.Core.Entities;
using NewsFood.Core.Entities.BaseEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsFood.Core.Interface.Repository
{
    public interface ICategoriesRepository<TEntity> : IBaseRepository<TEntity> where TEntity : IBaseEntity
    {
        Task<List<Categories>> GetCategories();
    }
}
