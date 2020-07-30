﻿
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                    new Product { Id = 1, Name = "Product 1" },
                    new Product { Id = 2, Name = "Product 2" },
                    new Product { Id = 3, Name = "Product 3" }
                );
        }
    }
}
