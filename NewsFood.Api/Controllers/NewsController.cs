using Microsoft.AspNetCore.Mvc;
using NewsFood.Core.BussinessService;
using NewsFood.Core.BussinessService.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsFood.Api.Controllers
{
    public class NewsController : AppBaseController
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<IEnumerable<NewsDto>> Get()
        {
            return await _newsService.GetAllNewsService();
        }
    }
}
