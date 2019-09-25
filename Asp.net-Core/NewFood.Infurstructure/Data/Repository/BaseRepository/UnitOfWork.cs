using NewFood.Infurstructure.Data.EntityFramework;
using NewsFood.Core;
using NewsFood.Core.BussinessService;
using NewsFood.Core.Entities.BaseEntities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NewFood.Infurstructure.Data.Repository
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The DbContext
        /// </summary>
        private ApplicationDbContext _dbContext;
        private Hashtable _repositories;

        public UnitOfWork(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int Commit()
        {
           return _dbContext.SaveChanges();
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }

        IRepository<TEntity> IUnitOfWork.Repository<TEntity>()
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;
            if (_repositories.ContainsKey(type)) return (IRepository<TEntity>)_repositories[type];
            var repositoryType = typeof(Repository<>);

            var repositoryInstance =
                Activator.CreateInstance(repositoryType
                    .MakeGenericType(typeof(TEntity)), _dbContext);
            _repositories.Add(type, repositoryInstance);

            return (IRepository<TEntity>)_repositories[type];
        }
    }
}
