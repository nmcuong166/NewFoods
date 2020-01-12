using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewsFood.Infurstructure.Data.Entities;
using NewsFood.Infurstructure.Data.EntityFramework;
using NewsFood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace NewsFood.Infurstructure.Data
{
    public class MyIdentityDataInitializer
    {
        private ApplicationDbContext _context;
        private UserManager<AppUsers> _userManager;
        private RoleManager<AppRoles> _roleManager;

        public MyIdentityDataInitializer(ApplicationDbContext context, UserManager<AppUsers> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void SeedAdminUser()
        {
            var user = new AppUsers
            {
                UserName = "SuperAdmin",
                Email = "nmcuong166@gmail.com",
            };

            if (!_context.Users.AsNoTracking().Any(s => s.UserName == "SuperAdmin"))
            {
                var rs = _userManager.CreateAsync(user, "SuperAdmin").Result;
                var ef = _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "SuperAdmin")).Result;
            }
        }

        public void SeedCategories()
        {
            var categories = new List<Categories>() {
                new Categories {
                    Title = "Home",
                    ParentId = null,
                },
                new Categories
                {
                    Title = "Archive",
                    ParentId = null,
                },
                new Categories
                {
                    Title = "Pages",
                    ParentId = null,
                },
                new Categories
                {
                    Title = "Mega",
                    ParentId = null,
                },
                new Categories
                {
                    Title = "About",
                    ParentId = null,
                }
            };

            if (!_context.Categories.AsNoTracking().Any())
            {
                _context.Categories.AddRange(categories);
                _context.SaveChanges();
            }
        }

    }
}
