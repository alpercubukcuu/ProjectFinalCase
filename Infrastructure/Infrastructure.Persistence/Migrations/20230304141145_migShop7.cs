using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migShop7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Shops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Shops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shops_CategoryId",
                table: "Shops",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_ProductId",
                table: "Shops",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Categories_CategoryId",
                table: "Shops",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Products_ProductId",
                table: "Shops",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Categories_CategoryId",
                table: "Shops");

            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Products_ProductId",
                table: "Shops");

            migrationBuilder.DropIndex(
                name: "IX_Shops_CategoryId",
                table: "Shops");

            migrationBuilder.DropIndex(
                name: "IX_Shops_ProductId",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Shops");
        }
    }
}
