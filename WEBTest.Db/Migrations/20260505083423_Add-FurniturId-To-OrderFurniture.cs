using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBtest.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddFurniturIdToOrderFurniture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Furniture_FurnitureOrders_OrderFurnitureId",
                table: "Furniture");

            migrationBuilder.DropIndex(
                name: "IX_Furniture_OrderFurnitureId",
                table: "Furniture");

            migrationBuilder.DropColumn(
                name: "OrderFurnitureId",
                table: "Furniture");

            migrationBuilder.AddColumn<int>(
                name: "FurniturId",
                table: "FurnitureOrders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FurnituresId",
                table: "FurnitureOrders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureOrders_FurnituresId",
                table: "FurnitureOrders",
                column: "FurnituresId");

            migrationBuilder.AddForeignKey(
                name: "FK_FurnitureOrders_Furniture_FurnituresId",
                table: "FurnitureOrders",
                column: "FurnituresId",
                principalTable: "Furniture",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FurnitureOrders_Furniture_FurnituresId",
                table: "FurnitureOrders");

            migrationBuilder.DropIndex(
                name: "IX_FurnitureOrders_FurnituresId",
                table: "FurnitureOrders");

            migrationBuilder.DropColumn(
                name: "FurniturId",
                table: "FurnitureOrders");

            migrationBuilder.DropColumn(
                name: "FurnituresId",
                table: "FurnitureOrders");

            migrationBuilder.AddColumn<int>(
                name: "OrderFurnitureId",
                table: "Furniture",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Furniture_OrderFurnitureId",
                table: "Furniture",
                column: "OrderFurnitureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Furniture_FurnitureOrders_OrderFurnitureId",
                table: "Furniture",
                column: "OrderFurnitureId",
                principalTable: "FurnitureOrders",
                principalColumn: "Id");
        }
    }
}
