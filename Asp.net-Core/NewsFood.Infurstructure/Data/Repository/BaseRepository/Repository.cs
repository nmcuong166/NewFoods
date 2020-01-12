using Microsoft.EntityFrameworkCore;
using NewsFood.Infurstructure.Data.EntityFramework;
using NewsFood.Core;
using NewsFood.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFood.Infurstructure.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public async Task<TEntity> GetAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public TEntity Insert(TEntity entity)
        {
            var rs = _dbSet.Add(entity);
            return rs.Entity;
        }

        public void Update(TEntity entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _dbContext.Remove(entity);
        }

    }
}
