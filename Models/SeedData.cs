using Microsoft.EntityFrameworkCore;
using System;

namespace InitCMS.Models
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory
                { 
                    
                    Name = "Shirt",
                    Description = "All Types of Shirt"
                },
                new ProductCategory
                {   
                   Id =2,
                    Name = "Pant",
                    Description = "All types of Pants"
                },

                new Product
                {
                    
                    Name = "Shirt",
                    PCode = "SS1",
                    Description = "POLO Shirt",
                    PurchasePrice = 100,
                    SellPrice = 150,
                    InStock = 100,
                    Sale = 10,
                    CreatedDate = DateTime.Parse("2020-06-01")

                },
                new Product
                {
                   
                    Name = "Shirt",
                    PCode = "SS2",
                    Description = "T Shirt",
                    PurchasePrice = 100,
                    SellPrice = 150,
                    InStock = 100,
                    Sale = 1,
                    CreatedDate = DateTime.Parse("2020-06-01")

                },
                new Product
                {
                   
                    Name = "Pant",
                    PCode = "SP1",
                    Description = "Jean Pant",
                    PurchasePrice = 120,
                    SellPrice = 200,
                    InStock = 100,
                    Sale = 0,
                    CreatedDate = DateTime.Parse("2020-06-01")

                }
                );
        }
    }
}
