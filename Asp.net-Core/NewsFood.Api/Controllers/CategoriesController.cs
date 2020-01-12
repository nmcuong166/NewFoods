using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsFood.Api.Presenters;
using NewsFood.Core.Common.Parameter;
using NewsFood.Core.Dto;
using NewsFood.Core.Dto.BussinessService;
using NewsFood.Core.Interface.Bussiness;
using NewsFood.Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace NewsFood.Api.Controllers
{
    [Authorize]
    public class CategoriesController : AppBaseController
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IInmemoryCacheService _inmemoryCacheService;
        public CategoriesController(
            ICategoriesService categoriesService,
            IInmemoryCacheService inmemoryCacheService
            )
        {
            _categoriesService = categoriesService;
            _inmemoryCacheService = inmemoryCacheService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            var result = await _inmemoryCacheService.GetOrCreateAsync<List<CategoriesRespone>>(CacheKey.CategoriesEntry, () => _categoriesService.GetCategoriesFromDb());
            if (result.Any())
            {
                return new JsonContentResult<List<CategoriesRespone>>(result, new BaseRespone(true));
            }
            return new JsonContentResult<List<CategoriesRespone>>(new BaseRespone(false));
        }
    }
}
