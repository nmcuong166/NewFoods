using NewFood.Data.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFood.Core.Repository
{
    public interface IWorkScope
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity;

        IQueryable<TEntity> All<TEntity>() where TEntity : Entity;

        IRepository<TEntity> Repository<TEntity>() where TEntity : Entity;

        Task SaveChanges();
    }
}
