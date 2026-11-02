using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_CommerceDTO.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreatedAt", "Description", "ImageUrl", "IsActive", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 101, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Android smartphone with a high-resolution display", "https://m.media-amazon.com/images/I/71TPda7cwUL._AC_SL1500_.jpg", true, "Samsung Galaxy S24", 799.99m, null },
                    { 2, 101, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Apple smartphone with advanced camera features", "https://m.media-amazon.com/images/I/81Os1SDWpcL._AC_SL1500_.jpg", true, "Apple iPhone 15", 799.00m, null },
                    { 3, 101, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Google smartphone with AI-powered features", "https://m.media-amazon.com/images/I/71H1ZqW6yDL._AC_SL1500_.jpg", true, "Google Pixel 8", 549.00m, null },
                    { 4, 102, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "15-inch laptop for work and everyday use", "https://m.media-amazon.com/images/I/71D2mKJ5qOL._AC_SL1500_.jpg", true, "Dell Inspiron 15", 649.99m, null },
                    { 5, 102, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Reliable laptop with a full HD display", "https://m.media-amazon.com/images/I/71Z2iJj3qUL._AC_SL1500_.jpg", true, "Lenovo IdeaPad 3", 499.99m, null },
                    { 6, 103, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Wireless noise-cancelling headphones", "https://m.media-amazon.com/images/I/61vJtKbAssL._AC_SL1500_.jpg", true, "Sony WH-1000XM5", 348.00m, null },
                    { 7, 103, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Portable wireless speaker with deep bass", "https://m.media-amazon.com/images/I/71H1ZqW6yDL._AC_SL1500_.jpg", true, "JBL Bluetooth Speaker", 129.95m, null },
                    { 8, 201, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Soft regular-fit cotton t-shirt", "https://m.media-amazon.com/images/I/61L5QgPvgqL._AC_SL1500_.jpg", true, "Men's Cotton T-Shirt", 19.99m, null },
                    { 9, 201, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Stretch denim slim-fit jeans", "https://m.media-amazon.com/images/I/71q5G8qF5qL._AC_SL1500_.jpg", true, "Men's Slim Fit Jeans", 39.99m, null },
                    { 10, 201, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Long-sleeve casual button-down shirt", "https://m.media-amazon.com/images/I/71N1Pq3x7UL._AC_SL1500_.jpg", true, "Men's Casual Shirt", 29.99m, null },
                    { 11, 202, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Warm and comfortable knit sweater", "https://m.media-amazon.com/images/I/71N1Pq3x7UL._AC_SL1500_.jpg", true, "Women's Knit Sweater", 34.99m, null },
                    { 12, 202, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Comfortable dress for everyday wear", "https://m.media-amazon.com/images/I/61L5QgPvgqL._AC_SL1500_.jpg", true, "Women's Casual Dress", 39.99m, null },
                    { 13, 202, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight shoes for running and walking", "https://m.media-amazon.com/images/I/71q5G8qF5qL._AC_SL1500_.jpg", true, "Women's Running Shoes", 59.99m, null },
                    { 14, 203, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Soft hooded sweatshirt for children", "https://m.media-amazon.com/images/I/71N1Pq3x7UL._AC_SL1500_.jpg", true, "Kids' Hooded Sweatshirt", 24.99m, null },
                    { 15, 301, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Compact table with a modern design", "https://m.media-amazon.com/images/I/71D2mKJ5qOL._AC_SL1500_.jpg", true, "Modern Coffee Table", 89.99m, null },
                    { 16, 301, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Adjustable chair with lumbar support", "https://m.media-amazon.com/images/I/71Z2iJj3qUL._AC_SL1500_.jpg", true, "Ergonomic Office Chair", 159.99m, null },
                    { 17, 302, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Multi-piece cookware set for everyday cooking", "https://m.media-amazon.com/images/I/71TPda7cwUL._AC_SL1500_.jpg", true, "Non-Stick Cookware Set", 79.99m, null },
                    { 18, 302, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Programmable coffee maker with reusable filter", "https://m.media-amazon.com/images/I/61vJtKbAssL._AC_SL1500_.jpg", true, "Programmable Coffee Maker", 49.99m, null },
                    { 19, 303, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Round decorative mirror for home interiors", "https://m.media-amazon.com/images/I/71H1ZqW6yDL._AC_SL1500_.jpg", true, "Decorative Wall Mirror", 44.99m, null },
                    { 20, 303, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Dimmable lamp for desk or bedside use", "https://m.media-amazon.com/images/I/81Os1SDWpcL._AC_SL1500_.jpg", true, "LED Table Lamp", 29.99m, null },
                    { 21, 401, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Daily moisturizer for hydrated skin", "https://m.media-amazon.com/images/I/71TPda7cwUL._AC_SL1500_.jpg", true, "Hydrating Face Moisturizer", 18.99m, null },
                    { 22, 401, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Brightening facial serum", "https://m.media-amazon.com/images/I/61vJtKbAssL._AC_SL1500_.jpg", true, "Vitamin C Face Serum", 21.99m, null },
                    { 23, 402, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gentle shampoo for everyday use", "https://m.media-amazon.com/images/I/71H1ZqW6yDL._AC_SL1500_.jpg", true, "Daily Shampoo", 12.99m, null },
                    { 24, 402, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Conditioner for smooth and manageable hair", "https://m.media-amazon.com/images/I/81Os1SDWpcL._AC_SL1500_.jpg", true, "Nourishing Hair Conditioner", 13.99m, null },
                    { 25, 403, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Long-lasting matte lipstick", "https://m.media-amazon.com/images/I/61L5QgPvgqL._AC_SL1500_.jpg", true, "Matte Lipstick", 14.99m, null },
                    { 26, 403, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Versatile palette with multiple shades", "https://m.media-amazon.com/images/I/71N1Pq3x7UL._AC_SL1500_.jpg", true, "Eye Makeup Palette", 24.99m, null },
                    { 27, 501, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Space-saving weights for home workouts", "https://m.media-amazon.com/images/I/71D2mKJ5qOL._AC_SL1500_.jpg", true, "Adjustable Dumbbells", 89.99m, null },
                    { 28, 501, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Non-slip exercise mat with carrying strap", "https://m.media-amazon.com/images/I/71Z2iJj3qUL._AC_SL1500_.jpg", true, "Yoga Mat", 22.99m, null },
                    { 29, 502, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Reusable bottle for sports and travel", "https://m.media-amazon.com/images/I/71TPda7cwUL._AC_SL1500_.jpg", true, "Insulated Water Bottle", 24.99m, null },
                    { 30, 502, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Durable backpack for outdoor adventures", "https://m.media-amazon.com/images/I/61vJtKbAssL._AC_SL1500_.jpg", true, "Camping Backpack", 69.99m, null },
                    { 31, 503, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight moisture-wicking shorts", "https://m.media-amazon.com/images/I/61L5QgPvgqL._AC_SL1500_.jpg", true, "Performance Running Shorts", 21.99m, null },
                    { 32, 503, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Breathable shirt for training", "https://m.media-amazon.com/images/I/71q5G8qF5qL._AC_SL1500_.jpg", true, "Training Sports T-Shirt", 19.99m, null },
                    { 33, 601, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Collection of bestselling mystery novels", "https://m.media-amazon.com/images/I/71N1Pq3x7UL._AC_SL1500_.jpg", true, "Mystery Novel Collection", 32.99m, null },
                    { 34, 601, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "A timeless work of classic fiction", "https://m.media-amazon.com/images/I/71H1ZqW6yDL._AC_SL1500_.jpg", true, "Classic Fiction Novel", 14.99m, null },
                    { 35, 602, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Practical guide to personal finance", "https://m.media-amazon.com/images/I/81Os1SDWpcL._AC_SL1500_.jpg", true, "Personal Finance Guide", 18.99m, null },
                    { 36, 602, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Recipes and tips for healthy cooking", "https://m.media-amazon.com/images/I/71TPda7cwUL._AC_SL1500_.jpg", true, "Healthy Cooking Book", 24.99m, null },
                    { 37, 603, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Illustrated stories for young readers", "https://m.media-amazon.com/images/I/61L5QgPvgqL._AC_SL1500_.jpg", true, "Children's Storybook", 11.99m, null },
                    { 38, 603, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Fun learning activities for children", "https://m.media-amazon.com/images/I/71N1Pq3x7UL._AC_SL1500_.jpg", true, "Early Learning Activity Book", 9.99m, null },
                    { 39, 701, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Collectible superhero action figure", "https://m.media-amazon.com/images/I/71D2mKJ5qOL._AC_SL1500_.jpg", true, "Superhero Action Figure", 19.99m, null },
                    { 40, 701, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Creative construction blocks for children", "https://m.media-amazon.com/images/I/71Z2iJj3qUL._AC_SL1500_.jpg", true, "Building Blocks Set", 29.99m, null },
                    { 41, 702, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Strategy game for family game nights", "https://m.media-amazon.com/images/I/71TPda7cwUL._AC_SL1500_.jpg", true, "Family Strategy Board Game", 34.99m, null },
                    { 42, 702, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Fast and entertaining card game", "https://m.media-amazon.com/images/I/61vJtKbAssL._AC_SL1500_.jpg", true, "Classic Card Game", 8.99m, null },
                    { 43, 703, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Challenging jigsaw puzzle for adults", "https://m.media-amazon.com/images/I/71H1ZqW6yDL._AC_SL1500_.jpg", true, "1000-Piece Landscape Puzzle", 16.99m, null },
                    { 44, 703, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Colorful puzzle for young children", "https://m.media-amazon.com/images/I/81Os1SDWpcL._AC_SL1500_.jpg", true, "Kids' Animal Puzzle", 12.99m, null },
                    { 45, 801, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Selection of popular packaged snacks", "https://m.media-amazon.com/images/I/71TPda7cwUL._AC_SL1500_.jpg", true, "Assorted Snack Box", 22.99m, null },
                    { 46, 801, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Crunchy granola for breakfast and snacks", "https://m.media-amazon.com/images/I/61L5QgPvgqL._AC_SL1500_.jpg", true, "Organic Granola", 8.99m, null },
                    { 47, 802, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Rich roasted coffee for everyday brewing", "https://m.media-amazon.com/images/I/71N1Pq3x7UL._AC_SL1500_.jpg", true, "Ground Coffee", 14.99m, null },
                    { 48, 802, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Refreshing green tea bags", "https://m.media-amazon.com/images/I/71q5G8qF5qL._AC_SL1500_.jpg", true, "Green Tea Bags", 6.99m, null },
                    { 49, 803, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Long-grain rice for everyday meals", "https://m.media-amazon.com/images/I/71D2mKJ5qOL._AC_SL1500_.jpg", true, "Basmati Rice", 18.99m, null },
                    { 50, 803, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Pantry staple for baking and cooking", "https://m.media-amazon.com/images/I/71Z2iJj3qUL._AC_SL1500_.jpg", true, "All-Purpose Flour", 5.99m, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
