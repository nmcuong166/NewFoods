using Microsoft.EntityFrameworkCore;
using NewsFood.Infurstructure.Data.Repository.BaseRepository;
using NewsFood.Core.Entities;
using NewsFood.Core.Entities.BaseEntities;
using NewsFood.Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsFood.Infurstructure.Data.Repository
{
    public class CategoriesRepository<TEntity>  : BaseRepository<TEntity>, ICategoriesRepository<TEntity> where TEntity : BaseEntity
    {
        public CategoriesRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {}

        public async Task<List<Categories>> GetCategories()
        {
            var categories = await _unitOfWork.Repository<Categories>().GetAll().ToListAsync();
            return categories;
        }
    }
}
