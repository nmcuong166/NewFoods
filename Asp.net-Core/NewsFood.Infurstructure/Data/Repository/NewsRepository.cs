using Microsoft.EntityFrameworkCore;
using NewsFood.Infurstructure.Data.Repository.BaseRepository;
using NewsFood.Core.Entities;
using NewsFood.Core.Entities.BaseEntities;
using NewsFood.Core.Interface.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsFood.Infurstructure.Data.Repository
{
    public class NewsRepository<TEntity> : BaseRepository<TEntity>, INewsRepository<TEntity> where TEntity : BaseEntity
    {
        public NewsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {}

        public async Task<IEnumerable<News>> GetAll()
        {
            var newsAll = await _unitOfWork.Repository<News>().GetAll().ToListAsync();
            return newsAll;
        }
    }
}
