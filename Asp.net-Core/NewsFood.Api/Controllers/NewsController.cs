using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsFood.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewsFood.Core.Interface.Bussiness;

namespace NewsFood.Api.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class NewsController : AppBaseController
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var content = new ContentResult();
            //content.StatusCode = StatusCode()
            return Ok(await _newsService.GetAllNewsServiceAsync());
        }

    }
}
