using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsFood.Core.BussinessService;
using NewsFood.Core.Dto;
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _newsService.GetAllNewsService());
        }
    }
}
