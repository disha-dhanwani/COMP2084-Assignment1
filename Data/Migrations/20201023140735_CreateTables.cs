using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SneakerBoxStore.Data.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrandCategories",
                columns: table => new
                {
                    BrandCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandCategories", x => x.BrandCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Province = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    CreditCard = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Sneakers",
                columns: table => new
                {
                    SneakerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandCategoryId = table.Column<int>(nullable: false),
                    ModelName = table.Column<string>(nullable: false),
                    ReleaseYear = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Material = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    InStock = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sneakers", x => x.SneakerId);
                    table.ForeignKey(
                        name: "FKey_Sneakers_BrandCategoryId",
                        column: x => x.BrandCategoryId,
                        principalTable: "BrandCategories",
                        principalColumn: "BrandCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    SneakerId = table.Column<int>(nullable: false),
                    SneakerSize = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    ShipDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FKey_OrderDetails_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FKey_OrderDetails_SneakerId",
                        column: x => x.SneakerId,
                        principalTable: "Sneakers",
                        principalColumn: "SneakerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SneakerId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<int>(nullable: false),
                    DateModified = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FKey_ShoppingCarts_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FKey_ShoppingCarts_SneakerId",
                        column: x => x.SneakerId,
                        principalTable: "Sneakers",
                        principalColumn: "SneakerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CustomerId",
                table: "OrderDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_SneakerId",
                table: "OrderDetails",
                column: "SneakerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_CustomerId",
                table: "ShoppingCarts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_SneakerId",
                table: "ShoppingCarts",
                column: "SneakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sneakers_BrandCategoryId",
                table: "Sneakers",
                column: "BrandCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Sneakers");

            migrationBuilder.DropTable(
                name: "BrandCategories");
        }
    }
}
