using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBtest.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddDeliveryUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryUserId",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryUserId",
                table: "Orders",
                column: "DeliveryUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryUsers_DeliveryUserId",
                table: "Orders",
                column: "DeliveryUserId",
                principalTable: "DeliveryUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryUsers_DeliveryUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryUserId",
                table: "Orders");
        }
    }
}
