using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NewFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewFood.Data.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<News> News { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
               
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
