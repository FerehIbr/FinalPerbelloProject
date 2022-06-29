using Microsoft.EntityFrameworkCore.Migrations;

namespace pobena.Migrations
{
    public partial class BasketChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DiscountPrice",
                table: "ProductColorSizes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ProductColorSizes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "StockCount",
                table: "ProductColorSizes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "ProductColorSizes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductColorSizes");

            migrationBuilder.DropColumn(
                name: "StockCount",
                table: "ProductColorSizes");
        }
    }
}
