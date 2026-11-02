using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_CommerceDTO.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
