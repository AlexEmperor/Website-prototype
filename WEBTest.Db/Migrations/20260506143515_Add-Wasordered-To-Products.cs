using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBtest.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddWasorderedToProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FurniturId",
                table: "FurnitureOrders");

            migrationBuilder.AddColumn<int>(
                name: "Wasordered",
                table: "Products",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Wasordered",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "FurniturId",
                table: "FurnitureOrders",
                type: "integer",
                nullable: true);
        }
    }
}
