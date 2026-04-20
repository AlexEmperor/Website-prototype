using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBtest.Db.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDeparNumberToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeparNumbe",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeparNumbe",
                table: "Orders",
                type: "integer",
                nullable: true);
        }
    }
}
