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
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Categories
            var categorySeedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Electronic devices and accessories", DisplayOrder = 1, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 2, Name = "Clothing", Description = "Apparel for men and women", DisplayOrder = 2, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 3, Name = "Home & Kitchen", Description = "Products for your home and kitchen", DisplayOrder = 3, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 4, Name = "Beauty & Personal Care", Description = "Beauty and personal care products", DisplayOrder = 4, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 5, Name = "Sports & Fitness", Description = "Sports equipment and fitness products", DisplayOrder = 5, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 6, Name = "Books", Description = "Books and reading materials", DisplayOrder = 6, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 7, Name = "Toys & Games", Description = "Toys and games for all ages", DisplayOrder = 7, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 8, Name = "Grocery", Description = "Food and grocery products", DisplayOrder = 8, CreatedAt = categorySeedDate, IsActive = true },

                new Category { Id = 101, Name = "Mobile Phones", Description = "Smartphones and mobile phones", ParentCategoryId = 1, DisplayOrder = 1, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 102, Name = "Laptops", Description = "Laptops and notebooks", ParentCategoryId = 1, DisplayOrder = 2, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 103, Name = "Audio", Description = "Headphones, speakers, and audio accessories", ParentCategoryId = 1, DisplayOrder = 3, CreatedAt = categorySeedDate, IsActive = true },

                new Category { Id = 201, Name = "Men's Clothing", Description = "Clothing for men", ParentCategoryId = 2, DisplayOrder = 1, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 202, Name = "Women's Clothing", Description = "Clothing for women", ParentCategoryId = 2, DisplayOrder = 2, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 203, Name = "Kids' Clothing", Description = "Clothing for children", ParentCategoryId = 2, DisplayOrder = 3, CreatedAt = categorySeedDate, IsActive = true },

                new Category { Id = 301, Name = "Furniture", Description = "Furniture for every room", ParentCategoryId = 3, DisplayOrder = 1, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 302, Name = "Kitchen Appliances", Description = "Appliances for your kitchen", ParentCategoryId = 3, DisplayOrder = 2, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 303, Name = "Home Decor", Description = "Decorations and accessories for your home", ParentCategoryId = 3, DisplayOrder = 3, CreatedAt = categorySeedDate, IsActive = true },

                new Category { Id = 401, Name = "Skincare", Description = "Skincare products", ParentCategoryId = 4, DisplayOrder = 1, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 402, Name = "Haircare", Description = "Haircare products", ParentCategoryId = 4, DisplayOrder = 2, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 403, Name = "Makeup", Description = "Makeup and cosmetics", ParentCategoryId = 4, DisplayOrder = 3, CreatedAt = categorySeedDate, IsActive = true },

                new Category { Id = 501, Name = "Exercise Equipment", Description = "Equipment for home and gym workouts", ParentCategoryId = 5, DisplayOrder = 1, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 502, Name = "Outdoor Sports", Description = "Products for outdoor sports", ParentCategoryId = 5, DisplayOrder = 2, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 503, Name = "Sportswear", Description = "Clothing and accessories for sports", ParentCategoryId = 5, DisplayOrder = 3, CreatedAt = categorySeedDate, IsActive = true },

                new Category { Id = 601, Name = "Fiction", Description = "Fiction books and novels", ParentCategoryId = 6, DisplayOrder = 1, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 602, Name = "Non-Fiction", Description = "Non-fiction books", ParentCategoryId = 6, DisplayOrder = 2, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 603, Name = "Children's Books", Description = "Books for children", ParentCategoryId = 6, DisplayOrder = 3, CreatedAt = categorySeedDate, IsActive = true },

                new Category { Id = 701, Name = "Action Figures", Description = "Action figures and collectibles", ParentCategoryId = 7, DisplayOrder = 1, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 702, Name = "Board Games", Description = "Board games for family and friends", ParentCategoryId = 7, DisplayOrder = 2, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 703, Name = "Puzzles", Description = "Puzzles for children and adults", ParentCategoryId = 7, DisplayOrder = 3, CreatedAt = categorySeedDate, IsActive = true },

                new Category { Id = 801, Name = "Snacks", Description = "Packaged snacks and treats", ParentCategoryId = 8, DisplayOrder = 1, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 802, Name = "Beverages", Description = "Drinks and beverages", ParentCategoryId = 8, DisplayOrder = 2, CreatedAt = categorySeedDate, IsActive = true },
                new Category { Id = 803, Name = "Staples", Description = "Everyday grocery staples", ParentCategoryId = 8, DisplayOrder = 3, CreatedAt = categorySeedDate, IsActive = true }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Samsung Galaxy S24", Description = "Android smartphone with a high-resolution display", Price = 799.99m, CategoryId = 101, ImageUrl = "https://m.media-amazon.com/images/I/716UvwH-NvL._AC_UY218_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 2, Name = "Apple iPhone 15", Description = "Apple smartphone with advanced camera features", Price = 799.00m, CategoryId = 101, ImageUrl = "https://m.media-amazon.com/images/I/41QFuCkTTPL._AC_UY218_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 3, Name = "Google Pixel 8", Description = "Google smartphone with AI-powered features", Price = 549.00m, CategoryId = 101, ImageUrl = "https://m.media-amazon.com/images/I/71SfoZu9a3L._AC_UY218_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 4, Name = "Dell Inspiron 15", Description = "15-inch laptop for work and everyday use", Price = 649.99m, CategoryId = 102, ImageUrl = "https://m.media-amazon.com/images/I/716iBSQR0gL._AC_UY218_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 5, Name = "Lenovo IdeaPad 3", Description = "Reliable laptop with a full HD display", Price = 499.99m, CategoryId = 102, ImageUrl = "https://m.media-amazon.com/images/I/81M05PyYgYL._AC_UY218_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 6, Name = "Sony WH-1000XM5", Description = "Wireless noise-cancelling headphones", Price = 348.00m, CategoryId = 103, ImageUrl = "https://m.media-amazon.com/images/I/61O3iMlnJIL._AC_UY218_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 7, Name = "JBL Bluetooth Speaker", Description = "Portable wireless speaker with deep bass", Price = 129.95m, CategoryId = 103, ImageUrl = "https://m.media-amazon.com/images/I/81pM9-KLvqL._AC_UY218_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 8, Name = "Men's Cotton T-Shirt", Description = "Soft regular-fit cotton t-shirt", Price = 19.99m, CategoryId = 201, ImageUrl = "https://m.media-amazon.com/images/I/81dwpsGxzVL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 9, Name = "Men's Slim Fit Jeans", Description = "Stretch denim slim-fit jeans", Price = 39.99m, CategoryId = 201, ImageUrl = "https://m.media-amazon.com/images/I/51u1XGKtzvL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 10, Name = "Men's Casual Shirt", Description = "Long-sleeve casual button-down shirt", Price = 29.99m, CategoryId = 201, ImageUrl = "https://m.media-amazon.com/images/I/81TSrTXy8TL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 11, Name = "Women's Knit Sweater", Description = "Warm and comfortable knit sweater", Price = 34.99m, CategoryId = 202, ImageUrl = "https://m.media-amazon.com/images/I/71l9N09tGUL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 12, Name = "Women's Casual Dress", Description = "Comfortable dress for everyday wear", Price = 39.99m, CategoryId = 202, ImageUrl = "https://m.media-amazon.com/images/I/61Fe4pQP+HL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 13, Name = "Women's Running Shoes", Description = "Lightweight shoes for running and walking", Price = 59.99m, CategoryId = 202, ImageUrl = "https://m.media-amazon.com/images/I/71BbYFrKR5L._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 14, Name = "Kids' Hooded Sweatshirt", Description = "Soft hooded sweatshirt for children", Price = 24.99m, CategoryId = 203, ImageUrl = "https://m.media-amazon.com/images/I/717RqETBjnL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 15, Name = "Modern Coffee Table", Description = "Compact table with a modern design", Price = 89.99m, CategoryId = 301, ImageUrl = "https://m.media-amazon.com/images/I/51debm8Ty0L._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 16, Name = "Ergonomic Office Chair", Description = "Adjustable chair with lumbar support", Price = 159.99m, CategoryId = 301, ImageUrl = "https://m.media-amazon.com/images/I/81BLi0KQXeL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 17, Name = "Non-Stick Cookware Set", Description = "Multi-piece cookware set for everyday cooking", Price = 79.99m, CategoryId = 302, ImageUrl = "https://m.media-amazon.com/images/I/71LmApZEJQL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 18, Name = "Programmable Coffee Maker", Description = "Programmable coffee maker with reusable filter", Price = 49.99m, CategoryId = 302, ImageUrl = "https://m.media-amazon.com/images/I/61Rdl5C2AHL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 19, Name = "Decorative Wall Mirror", Description = "Round decorative mirror for home interiors", Price = 44.99m, CategoryId = 303, ImageUrl = "https://m.media-amazon.com/images/I/81dW89kthiL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 20, Name = "LED Table Lamp", Description = "Dimmable lamp for desk or bedside use", Price = 29.99m, CategoryId = 303, ImageUrl = "https://m.media-amazon.com/images/I/61N+Cn7-R2L._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 21, Name = "Hydrating Face Moisturizer", Description = "Daily moisturizer for hydrated skin", Price = 18.99m, CategoryId = 401, ImageUrl = "https://m.media-amazon.com/images/I/71yhmPp-fqL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 22, Name = "Vitamin C Face Serum", Description = "Brightening facial serum", Price = 21.99m, CategoryId = 401, ImageUrl = "https://m.media-amazon.com/images/I/71XKWmqo+qL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 23, Name = "Daily Shampoo", Description = "Gentle shampoo for everyday use", Price = 12.99m, CategoryId = 402, ImageUrl = "https://m.media-amazon.com/images/I/51TQAX7X8pL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 24, Name = "Nourishing Hair Conditioner", Description = "Conditioner for smooth and manageable hair", Price = 13.99m, CategoryId = 402, ImageUrl = "https://m.media-amazon.com/images/I/61XRloX5qrL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 25, Name = "Matte Lipstick", Description = "Long-lasting matte lipstick", Price = 14.99m, CategoryId = 403, ImageUrl = "https://m.media-amazon.com/images/I/61v8Qp57WHL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 26, Name = "Eye Makeup Palette", Description = "Versatile palette with multiple shades", Price = 24.99m, CategoryId = 403, ImageUrl = "https://m.media-amazon.com/images/I/81sIQiQD5gL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 27, Name = "Adjustable Dumbbells", Description = "Space-saving weights for home workouts", Price = 89.99m, CategoryId = 501, ImageUrl = "https://m.media-amazon.com/images/I/51p1r3aEEzL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 28, Name = "Yoga Mat", Description = "Non-slip exercise mat with carrying strap", Price = 22.99m, CategoryId = 501, ImageUrl = "https://m.media-amazon.com/images/I/61JebJK2odL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 29, Name = "Insulated Water Bottle", Description = "Reusable bottle for sports and travel", Price = 24.99m, CategoryId = 502, ImageUrl = "https://m.media-amazon.com/images/I/61oyOiqDIlL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 30, Name = "Camping Backpack", Description = "Durable backpack for outdoor adventures", Price = 69.99m, CategoryId = 502, ImageUrl = "https://m.media-amazon.com/images/I/610BlWcc8lL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 31, Name = "Performance Running Shorts", Description = "Lightweight moisture-wicking shorts", Price = 21.99m, CategoryId = 503, ImageUrl = "https://m.media-amazon.com/images/I/81o2m9kbAOL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 32, Name = "Training Sports T-Shirt", Description = "Breathable shirt for training", Price = 19.99m, CategoryId = 503, ImageUrl = "https://m.media-amazon.com/images/I/81VfvFPHMRL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 33, Name = "Mystery Novel Collection", Description = "Collection of bestselling mystery novels", Price = 32.99m, CategoryId = 601, ImageUrl = "https://m.media-amazon.com/images/I/71e1Qi1JMHL._AC_UY218_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 34, Name = "Classic Fiction Novel", Description = "A timeless work of classic fiction", Price = 14.99m, CategoryId = 601, ImageUrl = "https://m.media-amazon.com/images/I/814qgx0BnYL._AC_UY218_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 35, Name = "Personal Finance Guide", Description = "Practical guide to personal finance", Price = 18.99m, CategoryId = 602, ImageUrl = "https://m.media-amazon.com/images/I/71TzzGUUTQL._AC_UY218_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 36, Name = "Healthy Cooking Book", Description = "Recipes and tips for healthy cooking", Price = 24.99m, CategoryId = 602, ImageUrl = "https://m.media-amazon.com/images/I/91O7oClYkoL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 37, Name = "Children's Storybook", Description = "Illustrated stories for young readers", Price = 11.99m, CategoryId = 603, ImageUrl = "https://m.media-amazon.com/images/I/91dbP2d-UvL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 38, Name = "Early Learning Activity Book", Description = "Fun learning activities for children", Price = 9.99m, CategoryId = 603, ImageUrl = "https://m.media-amazon.com/images/I/71qwu8pMkkL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 39, Name = "Superhero Action Figure", Description = "Collectible superhero action figure", Price = 19.99m, CategoryId = 701, ImageUrl = "https://m.media-amazon.com/images/I/71jlfOJLDTL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 40, Name = "Building Blocks Set", Description = "Creative construction blocks for children", Price = 29.99m, CategoryId = 701, ImageUrl = "https://m.media-amazon.com/images/I/91u6CEtezmL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 41, Name = "Family Strategy Board Game", Description = "Strategy game for family game nights", Price = 34.99m, CategoryId = 702, ImageUrl = "https://m.media-amazon.com/images/I/71KnAT1F6wL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 42, Name = "Classic Card Game", Description = "Fast and entertaining card game", Price = 8.99m, CategoryId = 702, ImageUrl = "https://m.media-amazon.com/images/I/81tVL-E4lkL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 43, Name = "1000-Piece Landscape Puzzle", Description = "Challenging jigsaw puzzle for adults", Price = 16.99m, CategoryId = 703, ImageUrl = "https://m.media-amazon.com/images/I/81A98fF7beL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 44, Name = "Kids' Animal Puzzle", Description = "Colorful puzzle for young children", Price = 12.99m, CategoryId = 703, ImageUrl = "https://m.media-amazon.com/images/I/81Bu5NphY+L._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 45, Name = "Assorted Snack Box", Description = "Selection of popular packaged snacks", Price = 22.99m, CategoryId = 801, ImageUrl = "https://m.media-amazon.com/images/I/81n4J-9KV0L._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 46, Name = "Organic Granola", Description = "Crunchy granola for breakfast and snacks", Price = 8.99m, CategoryId = 801, ImageUrl = "https://m.media-amazon.com/images/I/81MucxRSz2L._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 47, Name = "Ground Coffee", Description = "Rich roasted coffee for everyday brewing", Price = 14.99m, CategoryId = 802, ImageUrl = "https://m.media-amazon.com/images/I/613eoeq1eOL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 48, Name = "Green Tea Bags", Description = "Refreshing green tea bags", Price = 6.99m, CategoryId = 802, ImageUrl = "https://m.media-amazon.com/images/I/71LB3MapJ7L._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 49, Name = "Basmati Rice", Description = "Long-grain rice for everyday meals", Price = 18.99m, CategoryId = 803, ImageUrl = "https://m.media-amazon.com/images/I/811i97bIp4L._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true },
                new Product { ProductId = 50, Name = "All-Purpose Flour", Description = "Pantry staple for baking and cooking", Price = 5.99m, CategoryId = 803, ImageUrl = "https://m.media-amazon.com/images/I/71ZdqRUEokL._AC_UL320_.jpg", CreatedAt = categorySeedDate, IsActive = true }
            );

            // Seed Inventory
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { Id = 1, ProductId = 1, QuantityOnHand = 12, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 2, ProductId = 2, QuantityOnHand = 7, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 3, ProductId = 3, QuantityOnHand = 21, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 4, ProductId = 4, QuantityOnHand = 4, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 5, ProductId = 5, QuantityOnHand = 18, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 6, ProductId = 6, QuantityOnHand = 9, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 7, ProductId = 7, QuantityOnHand = 25, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 8, ProductId = 8, QuantityOnHand = 15, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 9, ProductId = 9, QuantityOnHand = 3, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 10, ProductId = 10, QuantityOnHand = 20, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 11, ProductId = 11, QuantityOnHand = 11, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 12, ProductId = 12, QuantityOnHand = 6, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 13, ProductId = 13, QuantityOnHand = 23, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 14, ProductId = 14, QuantityOnHand = 8, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 15, ProductId = 15, QuantityOnHand = 16, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 16, ProductId = 16, QuantityOnHand = 2, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 17, ProductId = 17, QuantityOnHand = 19, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 18, ProductId = 18, QuantityOnHand = 14, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 19, ProductId = 19, QuantityOnHand = 5, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 20, ProductId = 20, QuantityOnHand = 22, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 21, ProductId = 21, QuantityOnHand = 10, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 22, ProductId = 22, QuantityOnHand = 1, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 23, ProductId = 23, QuantityOnHand = 17, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 24, ProductId = 24, QuantityOnHand = 24, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 25, ProductId = 25, QuantityOnHand = 13, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 26, ProductId = 26, QuantityOnHand = 6, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 27, ProductId = 27, QuantityOnHand = 20, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 28, ProductId = 28, QuantityOnHand = 9, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 29, ProductId = 29, QuantityOnHand = 25, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 30, ProductId = 30, QuantityOnHand = 4, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 31, ProductId = 31, QuantityOnHand = 18, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 32, ProductId = 32, QuantityOnHand = 12, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 33, ProductId = 33, QuantityOnHand = 7, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 34, ProductId = 34, QuantityOnHand = 21, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 35, ProductId = 35, QuantityOnHand = 3, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 36, ProductId = 36, QuantityOnHand = 16, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 37, ProductId = 37, QuantityOnHand = 10, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 38, ProductId = 38, QuantityOnHand = 23, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 39, ProductId = 39, QuantityOnHand = 8, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 40, ProductId = 40, QuantityOnHand = 14, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 41, ProductId = 41, QuantityOnHand = 5, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 42, ProductId = 42, QuantityOnHand = 19, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 43, ProductId = 43, QuantityOnHand = 2, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 44, ProductId = 44, QuantityOnHand = 24, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 45, ProductId = 45, QuantityOnHand = 11, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 46, ProductId = 46, QuantityOnHand = 6, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 47, ProductId = 47, QuantityOnHand = 17, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 48, ProductId = 48, QuantityOnHand = 22, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 49, ProductId = 49, QuantityOnHand = 13, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate },
                new Inventory { Id = 50, ProductId = 50, QuantityOnHand = 1, ReservedQuantity = 0, ReorderLevel = 5, CreatedAt = categorySeedDate }
            );
        }
    }
}
