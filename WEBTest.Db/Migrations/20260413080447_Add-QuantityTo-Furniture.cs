using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBtest.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityToFurniture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Furniture",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Furniture");
        }
    }
}
