using NewsFood.Core.Dto;
using NewsFood.Core.Entities;
using NewsFood.Core.Interface.Bussiness;
using NewsFood.Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFood.Core.BusinessServices
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NewsService(INewsRepository newsRepository, IUnitOfWork unitOfWork)
        {
            _newsRepository = newsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<NewsDto>> GetAllNewsServiceAsync()
        {
            var newsRepo = await _newsRepository.GetAll();
            return newsRepo.Select(s => new NewsDto
            {
                Id = s.Id,
                Contents = s.Contens
            });
        }
    }

}
