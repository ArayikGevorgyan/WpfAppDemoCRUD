using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDemoCRUD.Data
{
    public class ProductDbContext : DbContext
    {

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        // Ensure the database is created
            Database.EnsureCreated();
        }
        // DbSet for products table
        public DbSet<Product> Products { get; set; }
        //Seed initial data into the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(GetProducts());
            base.OnModelCreating(modelBuilder);
        }

        private Product[] GetProducts()
        {//this part will make sure that this 4 reccords will be available once we have database, 
         //   but also I used  Database.EnsureCreated(); to be sure that database has been created.

            return new Product[]
            {
                new Product { Id = 1, Name = "Tshirt", Description = "Red", Price = 19.99, Unit =5},
                new Product { Id = 2, Name = "Tshirt", Description = "Blue Color", Price = 10.99, Unit =50},
                new Product { Id = 3, Name = "Shirt", Description = "Formal Shirt", Price = 10.99, Unit =25},
                new Product { Id = 4, Name = "Socks", Description = "Yellow ", Price = 2, Unit =500},
            };
        }

    }
}
