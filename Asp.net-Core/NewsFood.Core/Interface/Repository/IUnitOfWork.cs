using NewsFood.Core.Entities.BaseEntities;
using NewsFood.Core.Interface.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Interface.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
        IRepository<TEntity> Repository<TEntity>() where TEntity : Entity;
    }
}
