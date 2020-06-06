using System;
using System.Linq;
using InitCMS.Models;

namespace InitCMS.Data
{
    public static class DbInitializer
    {
        public static void Initialize(InitCMSContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.ProductCategory.Any())
            {
                return;   // DB has been seeded
            }

            var ProductCategories = new ProductCategory[]
            {
                new ProductCategory { Name = "Shirt",   Description = "All types of Shirts" },
                new ProductCategory { Name = "Pant",   Description = "All types of Pants" }

            };

            foreach (ProductCategory pc in ProductCategories)
            {
                context.ProductCategory.Add(pc);
            }
            context.SaveChanges();

            var products = new Product[]
           {
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

           };

            foreach (Product pc in products)
            {
                context.Products.Add(pc);
            }
            context.SaveChanges();
        }
    }
}
