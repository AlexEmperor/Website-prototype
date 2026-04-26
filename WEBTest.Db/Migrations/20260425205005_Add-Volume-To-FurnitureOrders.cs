using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBtest.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddVolumeToFurnitureOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Volume",
                table: "FurnitureOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Furniture",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Furniture_ProductId",
                table: "Furniture",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Furniture_Products_ProductId",
                table: "Furniture",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Furniture_Products_ProductId",
                table: "Furniture");

            migrationBuilder.DropIndex(
                name: "IX_Furniture_ProductId",
                table: "Furniture");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "FurnitureOrders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Furniture");
        }
    }
}
