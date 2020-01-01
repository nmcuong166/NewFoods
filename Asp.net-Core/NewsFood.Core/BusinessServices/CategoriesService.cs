using NewsFood.Core.Dto.BussinessService;
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
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository<Categories> _categoriesRepository;
        public CategoriesService(
            ICategoriesRepository<Categories> categoriesRepository
            )
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<List<CategoriesRespone>> GetCategoriesFromDb()
        {
            var listCategories = new List<CategoriesRespone>();

            var categories = (await _categoriesRepository.GetCategories()).Select(s => new CategoriesRespone
            {
                Id = s.Id,
                ParentId = s.ParentId,
                Title = s.Title
            }).ToList();

            if (categories.Any())
            {
                foreach (var category in categories)
                {
                    if (category.ParentId == null)
                    {
                        var item = new CategoriesRespone
                        {
                            ParentId = category.ParentId,
                            Title = category.Title,
                            Id = category.Id,
                        };
                        category.Checked = true;
                        item.SubCategories = RecuisiveCategories(categories, category.Id);
                        listCategories.Add(item);
                    }
                }
            }

            return listCategories;
        }

        private List<CategoriesRespone> RecuisiveCategories(List<CategoriesRespone> listCategory, long parrentId)
        {
            var cateogories = new List<CategoriesRespone>();
            foreach (var category in listCategory.Where(s => s.Checked == false))
            {
                if (category.ParentId == parrentId)
                {
                    var item = new CategoriesRespone
                    {
                        ParentId = category.ParentId,
                        Title = category.Title,
                        Id = category.Id,
                    };
                    category.Checked = true;
                    item.SubCategories = RecuisiveCategories(listCategory, category.Id);
                    cateogories.Add(item);
                }
            }
            return cateogories;
        }
    }
}
