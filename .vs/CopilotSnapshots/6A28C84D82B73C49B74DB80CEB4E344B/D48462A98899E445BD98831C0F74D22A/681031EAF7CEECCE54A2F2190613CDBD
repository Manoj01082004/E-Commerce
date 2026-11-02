using E_CommerceDTO.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceDTO.Context
{
    public class ECommerceDBContext(DbContextOptions<ECommerceDBContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Electronic devices and accessories", DisplayOrder = 1, CreatedAt = DateTime.UtcNow, IsActive = true },
                new Category { Id = 2, Name = "Clothing", Description = "Apparel for men and women", DisplayOrder = 2, CreatedAt = DateTime.UtcNow, IsActive = true }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Smartphone X", Description = "Latest smartphone with great features", Price = 699.99m, CategoryId = 1, ImageUrl = "https://example.com/images/phone.jpg", CreatedAt = DateTime.UtcNow, IsActive = true },
                new Product { ProductId = 2, Name = "Basic T-Shirt", Description = "Comfortable cotton t-shirt", Price = 19.99m, CategoryId = 2, ImageUrl = "https://example.com/images/tshirt.jpg", CreatedAt = DateTime.UtcNow, IsActive = true }
            );

            // Seed Inventories
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { Id = 1, ProductId = 1, QuantityOnHand = 50, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = DateTime.UtcNow },
                new Inventory { Id = 2, ProductId = 2, QuantityOnHand = 200, ReservedQuantity = 0, ReorderLevel = 20, CreatedAt = DateTime.UtcNow }
            );
        }
    }
}
