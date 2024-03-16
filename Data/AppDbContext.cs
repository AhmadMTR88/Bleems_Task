using Bleems_Task.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Bleems_Task.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}