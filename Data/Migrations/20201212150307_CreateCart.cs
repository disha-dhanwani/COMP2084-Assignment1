using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SneakerBoxStore.Data.Migrations
{
    public partial class CreateCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SneakerId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_Sneakers_SneakerId",
                        column: x => x.SneakerId,
                        principalTable: "Sneakers",
                        principalColumn: "SneakerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_SneakerId",
                table: "Carts",
                column: "SneakerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
