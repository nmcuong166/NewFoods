using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewFood.Data.BaseModels;

namespace NewsFood.Core.Repository
{
    public class WorkScope : IWorkScope
    {
        public IQueryable<TEntity> All<TEntity>() where TEntity : Entity
        {
            throw new NotImplementedException();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity
        {
            //(this as IWorkScope).geta
            return null;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : Entity
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
