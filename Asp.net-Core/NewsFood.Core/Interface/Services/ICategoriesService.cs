using NewsFood.Core.Dto.BussinessService;
using NewsFood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsFood.Core.Interface.Bussiness
{
    public interface ICategoriesService
    {
       Task<List<CategoriesRespone>> GetCategoriesFromDb(); 
    }
}
