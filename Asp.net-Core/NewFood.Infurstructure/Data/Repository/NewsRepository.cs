using Microsoft.EntityFrameworkCore;
using NewsFood.Core.Entities;
using NewsFood.Core.Interface.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewFood.Infurstructure.Data.Repository
{
    public class NewsRepository<TEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        public NewsRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<News>> GetAll()
        {
            var newsAll = await _unitOfWork.Repository<News>().GetAll().ToListAsync();
            return newsAll;
        }
    }
}
