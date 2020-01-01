using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsFood.Api.Presenters;
using NewsFood.Core.Dto;
using NewsFood.Core.Dto.BussinessService;
using NewsFood.Core.Interface.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFood.Api.Controllers
{
    [Authorize]
    public class CategoriesController : AppBaseController
    {
        private readonly ICategoriesService _categoriesService;
        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            var result = await _categoriesService.GetCategoriesFromDb();
            if (result.Any())
            {
                return new JsonContentResult<List<CategoriesRespone>>(result, new BaseRespone(true));
            }
            return new JsonContentResult<List<CategoriesRespone>>(new BaseRespone(false));
        }
    }
}
