using Microsoft.EntityFrameworkCore;
using InitCMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InitCMS.Data
{
    public class InitCMSContext : IdentityDbContext
    {
        public InitCMSContext(DbContextOptions<InitCMSContext> options)
         : base(options)
        {


        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory");

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.PCode)
                .IsUnique()
                .HasFilter("[PCode] is Not Null");
            
            modelBuilder.Entity<User>()
                .HasIndex(e => e.UserEmail)
                .IsUnique()
                .HasFilter("[UserEmail] is Not Null");

            //Seed Data
            // modelBuilder.Seed();
            /**
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory
                {

                    Name = "Shirt",
                    Description = "All Types of Shirt"
                },
                new ProductCategory
                {

                    Name = "Pant",
                    Description = "All types of Pants"
                }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {

                    Name = "Shirt",
                    PCode = "SS1",
                    Description = "POLO Shirt",
                    BuyPrice = 100,
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
                    BuyPrice = 100,
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
                    BuyPrice = 120,
                    SellPrice = 200,
                    InStock = 100,
                    Sale = 0,
                    CreatedDate = DateTime.Parse("2020-06-01")

                }
                );
            **/

        }

    }
}