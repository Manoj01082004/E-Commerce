using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductServices.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToProductDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "DisplayOrder", "ImageUrl", "IsActive", "Name", "ParentCategoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Electronic devices and accessories", 1, null, true, "Electronics", null, null },
                    { 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Apparel for men and women", 2, null, true, "Clothing", null, null },
                    { 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Products for your home and kitchen", 3, null, true, "Home & Kitchen", null, null },
                    { 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Beauty and personal care products", 4, null, true, "Beauty & Personal Care", null, null },
                    { 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Sports equipment and fitness products", 5, null, true, "Sports & Fitness", null, null },
                    { 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Books and reading materials", 6, null, true, "Books", null, null },
                    { 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Toys and games for all ages", 7, null, true, "Toys & Games", null, null },
                    { 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Food and grocery products", 8, null, true, "Grocery", null, null },
                    { 101, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Smartphones and mobile phones", 1, null, true, "Mobile Phones", 1, null },
                    { 102, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Laptops and notebooks", 2, null, true, "Laptops", 1, null },
                    { 103, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Headphones, speakers, and audio accessories", 3, null, true, "Audio", 1, null },
                    { 201, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Clothing for men", 1, null, true, "Men's Clothing", 2, null },
                    { 202, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Clothing for women", 2, null, true, "Women's Clothing", 2, null },
                    { 203, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Clothing for children", 3, null, true, "Kids' Clothing", 2, null },
                    { 301, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Furniture for every room", 1, null, true, "Furniture", 3, null },
                    { 302, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Appliances for your kitchen", 2, null, true, "Kitchen Appliances", 3, null },
                    { 303, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Decorations and accessories for your home", 3, null, true, "Home Decor", 3, null },
                    { 401, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Skincare products", 1, null, true, "Skincare", 4, null },
                    { 402, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Haircare products", 2, null, true, "Haircare", 4, null },
                    { 403, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Makeup and cosmetics", 3, null, true, "Makeup", 4, null },
                    { 501, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Equipment for home and gym workouts", 1, null, true, "Exercise Equipment", 5, null },
                    { 502, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Products for outdoor sports", 2, null, true, "Outdoor Sports", 5, null },
                    { 503, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Clothing and accessories for sports", 3, null, true, "Sportswear", 5, null },
                    { 601, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Fiction books and novels", 1, null, true, "Fiction", 6, null },
                    { 602, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Non-fiction books", 2, null, true, "Non-Fiction", 6, null },
                    { 603, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Books for children", 3, null, true, "Children's Books", 6, null },
                    { 701, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Action figures and collectibles", 1, null, true, "Action Figures", 7, null },
                    { 702, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Board games for family and friends", 2, null, true, "Board Games", 7, null },
                    { 703, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Puzzles for children and adults", 3, null, true, "Puzzles", 7, null },
                    { 801, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Packaged snacks and treats", 1, null, true, "Snacks", 8, null },
                    { 802, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Drinks and beverages", 2, null, true, "Beverages", 8, null },
                    { 803, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Everyday grocery staples", 3, null, true, "Staples", 8, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreatedAt", "Description", "ImageUrl", "IsActive", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 101, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Android smartphone with a high-resolution display", "https://m.media-amazon.com/images/I/716UvwH-NvL._AC_UY218_.jpg", true, "Samsung Galaxy S24", 799.99m, null },
                    { 2, 101, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Apple smartphone with advanced camera features", "https://m.media-amazon.com/images/I/41QFuCkTTPL._AC_UY218_.jpg", true, "Apple iPhone 15", 799.00m, null },
                    { 3, 101, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Google smartphone with AI-powered features", "https://m.media-amazon.com/images/I/71SfoZu9a3L._AC_UY218_.jpg", true, "Google Pixel 8", 549.00m, null },
                    { 4, 102, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "15-inch laptop for work and everyday use", "https://m.media-amazon.com/images/I/716iBSQR0gL._AC_UY218_.jpg", true, "Dell Inspiron 15", 649.99m, null },
                    { 5, 102, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Reliable laptop with a full HD display", "https://m.media-amazon.com/images/I/81M05PyYgYL._AC_UY218_.jpg", true, "Lenovo IdeaPad 3", 499.99m, null },
                    { 6, 103, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Wireless noise-cancelling headphones", "https://m.media-amazon.com/images/I/61O3iMlnJIL._AC_UY218_.jpg", true, "Sony WH-1000XM5", 348.00m, null },
                    { 7, 103, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Portable wireless speaker with deep bass", "https://m.media-amazon.com/images/I/81pM9-KLvqL._AC_UY218_.jpg", true, "JBL Bluetooth Speaker", 129.95m, null },
                    { 8, 201, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Soft regular-fit cotton t-shirt", "https://m.media-amazon.com/images/I/81dwpsGxzVL._AC_UL320_.jpg", true, "Men's Cotton T-Shirt", 19.99m, null },
                    { 9, 201, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Stretch denim slim-fit jeans", "https://m.media-amazon.com/images/I/51u1XGKtzvL._AC_UL320_.jpg", true, "Men's Slim Fit Jeans", 39.99m, null },
                    { 10, 201, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Long-sleeve casual button-down shirt", "https://m.media-amazon.com/images/I/81TSrTXy8TL._AC_UL320_.jpg", true, "Men's Casual Shirt", 29.99m, null },
                    { 11, 202, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Warm and comfortable knit sweater", "https://m.media-amazon.com/images/I/71l9N09tGUL._AC_UL320_.jpg", true, "Women's Knit Sweater", 34.99m, null },
                    { 12, 202, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Comfortable dress for everyday wear", "https://m.media-amazon.com/images/I/61Fe4pQP+HL._AC_UL320_.jpg", true, "Women's Casual Dress", 39.99m, null },
                    { 13, 202, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight shoes for running and walking", "https://m.media-amazon.com/images/I/71BbYFrKR5L._AC_UL320_.jpg", true, "Women's Running Shoes", 59.99m, null },
                    { 14, 203, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Soft hooded sweatshirt for children", "https://m.media-amazon.com/images/I/717RqETBjnL._AC_UL320_.jpg", true, "Kids' Hooded Sweatshirt", 24.99m, null },
                    { 15, 301, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Compact table with a modern design", "https://m.media-amazon.com/images/I/51debm8Ty0L._AC_UL320_.jpg", true, "Modern Coffee Table", 89.99m, null },
                    { 16, 301, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Adjustable chair with lumbar support", "https://m.media-amazon.com/images/I/81BLi0KQXeL._AC_UL320_.jpg", true, "Ergonomic Office Chair", 159.99m, null },
                    { 17, 302, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Multi-piece cookware set for everyday cooking", "https://m.media-amazon.com/images/I/71LmApZEJQL._AC_UL320_.jpg", true, "Non-Stick Cookware Set", 79.99m, null },
                    { 18, 302, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Programmable coffee maker with reusable filter", "https://m.media-amazon.com/images/I/61Rdl5C2AHL._AC_UL320_.jpg", true, "Programmable Coffee Maker", 49.99m, null },
                    { 19, 303, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Round decorative mirror for home interiors", "https://m.media-amazon.com/images/I/81dW89kthiL._AC_UL320_.jpg", true, "Decorative Wall Mirror", 44.99m, null },
                    { 20, 303, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Dimmable lamp for desk or bedside use", "https://m.media-amazon.com/images/I/61N+Cn7-R2L._AC_UL320_.jpg", true, "LED Table Lamp", 29.99m, null },
                    { 21, 401, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Daily moisturizer for hydrated skin", "https://m.media-amazon.com/images/I/71yhmPp-fqL._AC_UL320_.jpg", true, "Hydrating Face Moisturizer", 18.99m, null },
                    { 22, 401, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Brightening facial serum", "https://m.media-amazon.com/images/I/71XKWmqo+qL._AC_UL320_.jpg", true, "Vitamin C Face Serum", 21.99m, null },
                    { 23, 402, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gentle shampoo for everyday use", "https://m.media-amazon.com/images/I/51TQAX7X8pL._AC_UL320_.jpg", true, "Daily Shampoo", 12.99m, null },
                    { 24, 402, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Conditioner for smooth and manageable hair", "https://m.media-amazon.com/images/I/61XRloX5qrL._AC_UL320_.jpg", true, "Nourishing Hair Conditioner", 13.99m, null },
                    { 25, 403, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Long-lasting matte lipstick", "https://m.media-amazon.com/images/I/61v8Qp57WHL._AC_UL320_.jpg", true, "Matte Lipstick", 14.99m, null },
                    { 26, 403, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Versatile palette with multiple shades", "https://m.media-amazon.com/images/I/81sIQiQD5gL._AC_UL320_.jpg", true, "Eye Makeup Palette", 24.99m, null },
                    { 27, 501, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Space-saving weights for home workouts", "https://m.media-amazon.com/images/I/51p1r3aEEzL._AC_UL320_.jpg", true, "Adjustable Dumbbells", 89.99m, null },
                    { 28, 501, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Non-slip exercise mat with carrying strap", "https://m.media-amazon.com/images/I/61JebJK2odL._AC_UL320_.jpg", true, "Yoga Mat", 22.99m, null },
                    { 29, 502, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Reusable bottle for sports and travel", "https://m.media-amazon.com/images/I/61oyOiqDIlL._AC_UL320_.jpg", true, "Insulated Water Bottle", 24.99m, null },
                    { 30, 502, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Durable backpack for outdoor adventures", "https://m.media-amazon.com/images/I/610BlWcc8lL._AC_UL320_.jpg", true, "Camping Backpack", 69.99m, null },
                    { 31, 503, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight moisture-wicking shorts", "https://m.media-amazon.com/images/I/81o2m9kbAOL._AC_UL320_.jpg", true, "Performance Running Shorts", 21.99m, null },
                    { 32, 503, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Breathable shirt for training", "https://m.media-amazon.com/images/I/81VfvFPHMRL._AC_UL320_.jpg", true, "Training Sports T-Shirt", 19.99m, null },
                    { 33, 601, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Collection of bestselling mystery novels", "https://m.media-amazon.com/images/I/71e1Qi1JMHL._AC_UY218_.jpg", true, "Mystery Novel Collection", 32.99m, null },
                    { 34, 601, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "A timeless work of classic fiction", "https://m.media-amazon.com/images/I/814qgx0BnYL._AC_UY218_.jpg", true, "Classic Fiction Novel", 14.99m, null },
                    { 35, 602, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Practical guide to personal finance", "https://m.media-amazon.com/images/I/71TzzGUUTQL._AC_UY218_.jpg", true, "Personal Finance Guide", 18.99m, null },
                    { 36, 602, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Recipes and tips for healthy cooking", "https://m.media-amazon.com/images/I/91O7oClYkoL._AC_UL320_.jpg", true, "Healthy Cooking Book", 24.99m, null },
                    { 37, 603, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Illustrated stories for young readers", "https://m.media-amazon.com/images/I/91dbP2d-UvL._AC_UL320_.jpg", true, "Children's Storybook", 11.99m, null },
                    { 38, 603, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Fun learning activities for children", "https://m.media-amazon.com/images/I/71qwu8pMkkL._AC_UL320_.jpg", true, "Early Learning Activity Book", 9.99m, null },
                    { 39, 701, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Collectible superhero action figure", "https://m.media-amazon.com/images/I/71jlfOJLDTL._AC_UL320_.jpg", true, "Superhero Action Figure", 19.99m, null },
                    { 40, 701, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Creative construction blocks for children", "https://m.media-amazon.com/images/I/91u6CEtezmL._AC_UL320_.jpg", true, "Building Blocks Set", 29.99m, null },
                    { 41, 702, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Strategy game for family game nights", "https://m.media-amazon.com/images/I/71KnAT1F6wL._AC_UL320_.jpg", true, "Family Strategy Board Game", 34.99m, null },
                    { 42, 702, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Fast and entertaining card game", "https://m.media-amazon.com/images/I/81tVL-E4lkL._AC_UL320_.jpg", true, "Classic Card Game", 8.99m, null },
                    { 43, 703, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Challenging jigsaw puzzle for adults", "https://m.media-amazon.com/images/I/81A98fF7beL._AC_UL320_.jpg", true, "1000-Piece Landscape Puzzle", 16.99m, null },
                    { 44, 703, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Colorful puzzle for young children", "https://m.media-amazon.com/images/I/81Bu5NphY+L._AC_UL320_.jpg", true, "Kids' Animal Puzzle", 12.99m, null },
                    { 45, 801, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Selection of popular packaged snacks", "https://m.media-amazon.com/images/I/81n4J-9KV0L._AC_UL320_.jpg", true, "Assorted Snack Box", 22.99m, null },
                    { 46, 801, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Crunchy granola for breakfast and snacks", "https://m.media-amazon.com/images/I/81MucxRSz2L._AC_UL320_.jpg", true, "Organic Granola", 8.99m, null },
                    { 47, 802, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Rich roasted coffee for everyday brewing", "https://m.media-amazon.com/images/I/613eoeq1eOL._AC_UL320_.jpg", true, "Ground Coffee", 14.99m, null },
                    { 48, 802, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Refreshing green tea bags", "https://m.media-amazon.com/images/I/71LB3MapJ7L._AC_UL320_.jpg", true, "Green Tea Bags", 6.99m, null },
                    { 49, 803, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Long-grain rice for everyday meals", "https://m.media-amazon.com/images/I/811i97bIp4L._AC_UL320_.jpg", true, "Basmati Rice", 18.99m, null },
                    { 50, 803, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Pantry staple for baking and cooking", "https://m.media-amazon.com/images/I/71ZdqRUEokL._AC_UL320_.jpg", true, "All-Purpose Flour", 5.99m, null }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "CreatedAt", "LastRestockedAt", "ProductId", "QuantityOnHand", "ReorderLevel", "ReservedQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 1, 12, 5, 0, null },
                    { 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 2, 7, 5, 0, null },
                    { 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 3, 21, 5, 0, null },
                    { 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 4, 4, 5, 0, null },
                    { 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 5, 18, 5, 0, null },
                    { 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 6, 9, 5, 0, null },
                    { 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 7, 25, 5, 0, null },
                    { 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 8, 15, 5, 0, null },
                    { 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 9, 3, 5, 0, null },
                    { 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 10, 20, 5, 0, null },
                    { 11, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 11, 11, 5, 0, null },
                    { 12, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 12, 6, 5, 0, null },
                    { 13, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 13, 23, 5, 0, null },
                    { 14, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 14, 8, 5, 0, null },
                    { 15, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 15, 16, 5, 0, null },
                    { 16, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 16, 2, 5, 0, null },
                    { 17, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 17, 19, 5, 0, null },
                    { 18, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 18, 14, 5, 0, null },
                    { 19, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 19, 5, 5, 0, null },
                    { 20, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 20, 22, 5, 0, null },
                    { 21, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 21, 10, 5, 0, null },
                    { 22, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 22, 1, 5, 0, null },
                    { 23, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 23, 17, 5, 0, null },
                    { 24, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 24, 24, 5, 0, null },
                    { 25, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 25, 13, 5, 0, null },
                    { 26, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 26, 6, 5, 0, null },
                    { 27, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 27, 20, 5, 0, null },
                    { 28, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 28, 9, 5, 0, null },
                    { 29, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 29, 25, 5, 0, null },
                    { 30, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 30, 4, 5, 0, null },
                    { 31, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 31, 18, 5, 0, null },
                    { 32, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 32, 12, 5, 0, null },
                    { 33, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 33, 7, 5, 0, null },
                    { 34, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 34, 21, 5, 0, null },
                    { 35, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 35, 3, 5, 0, null },
                    { 36, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 36, 16, 5, 0, null },
                    { 37, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 37, 10, 5, 0, null },
                    { 38, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 38, 23, 5, 0, null },
                    { 39, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 39, 8, 5, 0, null },
                    { 40, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 40, 14, 5, 0, null },
                    { 41, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 41, 5, 5, 0, null },
                    { 42, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 42, 19, 5, 0, null },
                    { 43, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 43, 2, 5, 0, null },
                    { 44, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 44, 24, 5, 0, null },
                    { 45, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 45, 11, 5, 0, null },
                    { 46, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 46, 6, 5, 0, null },
                    { 47, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 47, 17, 5, 0, null },
                    { 48, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 48, 22, 5, 0, null },
                    { 49, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 49, 13, 5, 0, null },
                    { 50, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 50, 1, 5, 0, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 503);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 601);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 602);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 603);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 701);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 702);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 703);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 801);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 802);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 803);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
