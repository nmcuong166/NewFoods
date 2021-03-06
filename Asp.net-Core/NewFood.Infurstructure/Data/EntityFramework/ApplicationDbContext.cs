﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewFood.Infurstructure.Data.Entities;
using NewsFood.Core.Entities;
using NewsFood.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewFood.Infurstructure.Data.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext<AppUsers, AppRoles, long>
    {
        public virtual DbSet<News> News { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Do Nothing
        }

        public override int SaveChanges()
        {
            AddInfo();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddInfo();
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //SeedData(builder);
        }

        //private void SeedData(ModelBuilder builder)
        //{
        //    // data table News
        //    builder.Entity<News>().HasData(
        //      new News { Id = 1, Contens = "Cuong" },
        //      new News { Id = 2, Contens = "Lanh" });
        //}

        private void AddInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is IBaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((IBaseEntity)entry.Entity).CreationTime = DateTime.UtcNow;
                }
                ((IBaseEntity)entry.Entity).ModifiedTime = DateTime.UtcNow;
            }
        }
    }

}
