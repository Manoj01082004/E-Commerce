using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderServices.Migrations
{
    /// <inheritdoc />
    public partial class AddURLSandPriceToCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImageUrl",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductPrice",
                table: "CartItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImageUrl",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "CartItems");
        }
    }
}
