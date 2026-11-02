using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_CommerceDTO.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToCategory : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
