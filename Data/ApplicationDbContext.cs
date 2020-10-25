using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SneakerBoxStore.Models;

namespace SneakerBoxStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //Define our model class so controllers can access them.
        public DbSet<BrandCategory> BrandCategories { get; set; }
        public DbSet<Sneaker> Sneakers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Define relationships and keys
            //1. BrandCategory has a one-to-many relationship with Sneakers.
            builder.Entity<Sneaker>()
                .HasOne(s => s.BrandCategory)
                .WithMany(c => c.Sneakers)
                .HasForeignKey(s => s.BrandCategoryId)
                .HasConstraintName("FKey_Sneakers_BrandCategoryId");

            //2. Sneaker has a one-to-many relationship with OrderDetails.
            builder.Entity<OrderDetail>()
                .HasOne(s => s.Sneaker)
                .WithMany(c => c.OrderDetails)
                .HasForeignKey(s => s.SneakerId)
                .HasConstraintName("FKey_OrderDetails_SneakerId");

            //3. Customer has a one-to-many relationship with OrderDetails.
            builder.Entity<OrderDetail>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.OrderDetails)
                .HasForeignKey(s => s.CustomerId)
                .HasConstraintName("FKey_OrderDetails_CustomerId");

            //4. Sneaker has a one to many relationship with ShoppingCart.
            builder.Entity<ShoppingCart>()
                .HasOne(s => s.Sneaker)
                .WithMany(c => c.ShoppingCarts)
                .HasForeignKey(s => s.SneakerId)
                .HasConstraintName("FKey_ShoppingCarts_SneakerId");

            //5. Customer has a one-to-many relationship with ShoppingCart.
            builder.Entity<ShoppingCart>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.ShoppingCarts)
                .HasForeignKey(s => s.CustomerId)
                .HasConstraintName("FKey_ShoppingCarts_CustomerId");

            

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
