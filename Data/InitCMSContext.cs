 using Microsoft.EntityFrameworkCore;
using InitCMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using InitCMS.ViewModel;

namespace InitCMS.Data
{
    public class InitCMSContext : IdentityDbContext
    {
        public InitCMSContext(DbContextOptions<InitCMSContext> options)
         : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        //Purchase Order
        public DbSet<POViewModel> POViewModels { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<POStatus> POStatuses { get; set; }
        public DbSet<Coa> Coa { get; set; }
        public DbSet<CoaType> CoaType { get; set; }
        public DbSet<ExpenseEntry> ExpenseEntry { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory");
            modelBuilder.Entity<POViewModel>().ToTable("PurchaseOrder");

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.PCode)
                .IsUnique()
                .HasFilter("[PCode] is Not Null");
            
            modelBuilder.Entity<User>()
                .HasIndex(e => e.UserEmail)
                .IsUnique()
                .HasFilter("[UserEmail] is Not Null");

        }

    }
}