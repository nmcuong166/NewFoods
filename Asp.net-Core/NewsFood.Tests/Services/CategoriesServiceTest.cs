using Moq;
using NewsFood.Core.BusinessServices;
using NewsFood.Core.Dto.BussinessService;
using NewsFood.Core.Entities;
using NewsFood.Core.Interface.Repository;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsFood.Tests.Services
{
    [TestFixture]
    public class CategoriesServiceTest
    {
        private Mock<ICategoriesRepository<Categories>> _mockICategories;
        private CategoriesService _categoriesService;

        [SetUpAttribute]
        public void Setup()
        {
            _mockICategories = new Mock<ICategoriesRepository<Categories>>();
            _categoriesService = new CategoriesService(_mockICategories.Object);
        }

        private List<Categories> MockDataCategories()
        {
            return new List<Categories>()
            {
                new Categories { Id = 1, Title = "Home", ParentId = null },
                new Categories { Id = 2, Title = "News", ParentId = null },
                new Categories { Id = 3, Title = "Asian", ParentId = 2 },
                new Categories { Id = 4, Title = "Vietnam", ParentId = 3 },
            };
        }

        [Test]
        public async Task GetCategoriesFromDb_ValidGetCategories_ReturnListCategories()
        {
            var expexted = JsonConvert.SerializeObject(new List<CategoriesRespone>()
            {
                new CategoriesRespone
                {
                    Id = 1,
                    Title = "Home",
                    ParentId = null,
                    SubCategories = new List<CategoriesRespone>(),
                },
                new CategoriesRespone
                {
                    Id = 2, Title = "News",
                    ParentId = null,
                    SubCategories = new List<CategoriesRespone>()
                    {
                        new CategoriesRespone{
                        Id = 3,
                        Title = "Asian",
                        ParentId = 2,
                        SubCategories = new List<CategoriesRespone>()
                        {
                             new CategoriesRespone{
                                Id = 4,
                                Title = "Vietnam",
                                ParentId = 3,
                                SubCategories = new List<CategoriesRespone>()
                             }
                        }
                    }
                }}
            });

            _mockICategories.Setup(s => s.GetCategories()).ReturnsAsync(MockDataCategories());

            var result = JsonConvert.SerializeObject(await _categoriesService.GetCategoriesFromDb());

            Assert.AreEqual(expexted, result);
        }
    }
}
