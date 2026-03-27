using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEBtest.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalCostOrderToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                table: "Orders",
                type: "numeric",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 6, "Вязание" },
                    { 7, "Аксессуары" }
                });

            migrationBuilder.UpdateData(
                table: "Furniture",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "OrderPlace", "Price" },
                values: new object[] { "PED-G", "Пластик белый", "WB", 918m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Furniture",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "OrderPlace", "Price" },
                values: new object[] { "Петля мебельная", "Петля Hettich", "Germany", 120m });
        }
    }
}
