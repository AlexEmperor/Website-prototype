using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEBtest.Db.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comparisons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comparisons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Furniture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    OrderPlace = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furniture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FurnitureOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Provider = table.Column<string>(type: "text", nullable: false),
                    OrderCreationDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    OrderDeliveryDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "OrderFurnitureItems",
                columns: table => new
                {
                    OrderFurnitureId = table.Column<int>(type: "integer", nullable: false),
                    FurnitureId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderFurnitureItems", x => new { x.OrderFurnitureId, x.FurnitureId });
                    table.ForeignKey(
                        name: "FK_OrderFurnitureItems_FurnitureOrders_OrderFurnitureId",
                        column: x => x.OrderFurnitureId,
                        principalTable: "FurnitureOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderFurnitureItems_Furniture_FurnitureId",
                        column: x => x.FurnitureId,
                        principalTable: "Furniture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PhotoPath = table.Column<string>(type: "text", nullable: true),
                    Jpeg = table.Column<byte[]>(type: "bytea", nullable: true),
                    FurnitureOrderId = table.Column<int>(type: "integer", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: true),
                    Article = table.Column<string>(type: "text", nullable: true),
                    Barcode = table.Column<string>(type: "text", nullable: true),
                    Storage_Ozon = table.Column<int>(type: "integer", nullable: true),
                    Storage_FBS1 = table.Column<int>(type: "integer", nullable: true),
                    Cost_price = table.Column<int>(type: "integer", nullable: true),
                    Costs_Ozon = table.Column<int>(type: "integer", nullable: true),
                    Margin_FBO1 = table.Column<int>(type: "integer", nullable: true),
                    Margin_FBS1 = table.Column<int>(type: "integer", nullable: true),
                    ComparisonId = table.Column<Guid>(type: "uuid", nullable: true),
                    FavouriteId = table.Column<Guid>(type: "uuid", nullable: true),
                    FurnitureId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Comparisons_ComparisonId",
                        column: x => x.ComparisonId,
                        principalTable: "Comparisons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Favorites_FavouriteId",
                        column: x => x.FavouriteId,
                        principalTable: "Favorites",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_FurnitureOrders_FurnitureOrderId",
                        column: x => x.FurnitureOrderId,
                        principalTable: "FurnitureOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Furniture_FurnitureId",
                        column: x => x.FurnitureId,
                        principalTable: "Furniture",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CartId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Furniture",
                columns: new[] { "Id", "Description", "Name", "OrderPlace", "Price" },
                values: new object[,]
                {
                    { 1, "Петля мебельная", "Петля Hettich", "Germany", 120m },
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
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_OrderId",
                table: "CartItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureOrderFurniture_OrderFurnituresId",
                table: "FurnitureOrderFurniture",
                column: "OrderFurnituresId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFurnitureItems_FurnitureId",
                table: "OrderFurnitureItems",
                column: "FurnitureId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ComparisonId",
                table: "Products",
                column: "ComparisonId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FavouriteId",
                table: "Products",
                column: "FavouriteId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FurnitureId",
                table: "Products",
                column: "FurnitureId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FurnitureOrderId",
                table: "Products",
                column: "FurnitureOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "DeliveryUsers");

            migrationBuilder.DropTable(
                name: "FurnitureOrderFurniture");

            migrationBuilder.DropTable(
                name: "OrderFurnitureItems");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Comparisons");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "FurnitureOrders");

            migrationBuilder.DropTable(
                name: "Furniture");
        }
    }
}
