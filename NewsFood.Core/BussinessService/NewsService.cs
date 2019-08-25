using NewsFood.Core.BussinessService.Dto;
using NewsFood.Core.Entities;
using NewsFood.Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFood.Core.BussinessService
{
    public interface INewsService
    {
        Task<IEnumerable<NewsDto>> GetAllNewsService();
    }

    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        async Task<IEnumerable<NewsDto>> INewsService.GetAllNewsService()
        {
            var newsRepo = await _newsRepository.GetAll();
            return newsRepo.Select(s => new NewsDto {
                Id = s.Id,
                Contents = s.Contens
            });
        }
    }

}
