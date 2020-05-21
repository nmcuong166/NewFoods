using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsFood.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewsFood.Core.Interface.Bussiness;
using NewsFood.Core.Interface.Repository;
using NewsFood.Core.Entities;
using Microsoft.Extensions.Logging;

namespace NewsFood.Api.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class NewsController : AppBaseController
    {
        private readonly INewsService _newsService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public NewsController(INewsService newsService, IUnitOfWork unitOfWork, ILogger<NewsController> logger)
        {
            _newsService = newsService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var content = new ContentResult();
            return Ok(await _newsService.GetAllNewsServiceAsync());
        }
    }
}
