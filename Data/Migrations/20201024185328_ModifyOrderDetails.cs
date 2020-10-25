using Microsoft.EntityFrameworkCore.Migrations;

namespace SneakerBoxStore.Data.Migrations
{
    public partial class ModifyOrderDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "SneakerSize",
                table: "ShoppingCarts",
                nullable: false);

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "SneakerSize",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "ShoppingCarts");
        }
    }
}
