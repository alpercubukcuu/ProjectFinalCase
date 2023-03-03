using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_ShopLists_ShopListId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShopLists_ShopListId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ShopLists");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShopListId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ShopListId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ShopListId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShopListId",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopListId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShopListId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShopLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopLists", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShopListId",
                table: "Products",
                column: "ShopListId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ShopListId",
                table: "Categories",
                column: "ShopListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_ShopLists_ShopListId",
                table: "Categories",
                column: "ShopListId",
                principalTable: "ShopLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShopLists_ShopListId",
                table: "Products",
                column: "ShopListId",
                principalTable: "ShopLists",
                principalColumn: "Id");
        }
    }
}
