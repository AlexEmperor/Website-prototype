using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEBtest.Db.Migrations
{
    /// <inheritdoc />
    public partial class FixOrderFurniture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FurnitureOrders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderPlace",
                table: "FurnitureOrders",
                type: "text",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Furniture_FurnitureOrders_OrderFurnitureId",
                table: "Furniture");

            migrationBuilder.DropIndex(
                name: "IX_Furniture_OrderFurnitureId",
                table: "Furniture");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FurnitureOrders");

            migrationBuilder.DropColumn(
                name: "OrderPlace",
                table: "FurnitureOrders");

            migrationBuilder.DropColumn(
                name: "OrderFurnitureId",
                table: "Furniture");

            migrationBuilder.AddColumn<int>(
                name: "FurnitureId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FurnitureOrderFurniture",
                columns: table => new
                {
                    FurnituresId = table.Column<int>(type: "integer", nullable: false),
                    OrderFurnituresId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureOrderFurniture", x => new { x.FurnituresId, x.OrderFurnituresId });
                    table.ForeignKey(
                        name: "FK_FurnitureOrderFurniture_FurnitureOrders_OrderFurnituresId",
                        column: x => x.OrderFurnituresId,
                        principalTable: "FurnitureOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FurnitureOrderFurniture_Furniture_FurnituresId",
                        column: x => x.FurnituresId,
                        principalTable: "Furniture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Сережки" },
                    { 2, "Стройка" },
                    { 3, "Брошь" },
                    { 4, "Заколки" },
                    { 5, "Игрушки" },
                    { 6, "Вязание" },
                    { 7, "Аксессуары" },
                    { 8, "Брошь" },
                    { 9, "Браслеты" },
                    { 10, "Электроника" }
                });

            migrationBuilder.InsertData(
                table: "Furniture",
                columns: new[] { "Id", "Description", "Name", "OrderPlace", "Price" },
                values: new object[,]
                {
                    { 1, "PED-G", "Пластик белый", "WB", 918m },
                    { 2, "Газлифт мебельный", "Газлифт 100N", "China", 300m },
                    { 3, "Направляющие для ящиков", "Направляющие шариковые", "Poland", 450m }
                });

            migrationBuilder.InsertData(
                table: "FurnitureOrders",
                columns: new[] { "Id", "OrderCreationDateTime", "OrderDeliveryDateTime", "Price", "Provider" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000m, "Hettich" },
                    { 2, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 8000m, "Blum" }
                });

            migrationBuilder.InsertData(
                table: "OrderFurnitureItems",
                columns: new[] { "FurnitureId", "OrderFurnitureId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 20 },
                    { 3, 1, 10 },
                    { 2, 2, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_FurnitureId",
                table: "Products",
                column: "FurnitureId");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureOrderFurniture_OrderFurnituresId",
                table: "FurnitureOrderFurniture",
                column: "OrderFurnituresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Furniture_FurnitureId",
                table: "Products",
                column: "FurnitureId",
                principalTable: "Furniture",
                principalColumn: "Id");
        }
    }
}
