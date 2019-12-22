using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStore.Migrations
{
    public partial class Setup7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false),
                    ExpirationTime = table.Column<DateTimeOffset>(nullable: false),
                    ReserveDaysCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Balance = table.Column<double>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    CashBack = table.Column<double>(nullable: true),
                    CashBackPercent = table.Column<int>(nullable: true),
                    DiscountPercent = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Malls",
                columns: table => new
                {
                    MallId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malls", x => x.MallId);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    MallId = table.Column<Guid>(nullable: true),
                    Profit = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                    table.ForeignKey(
                        name: "FK_Stores_Malls_MallId",
                        column: x => x.MallId,
                        principalTable: "Malls",
                        principalColumn: "MallId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    CategoryName = table.Column<int>(nullable: false),
                    StoreId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ProductStatus = table.Column<int>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Malls",
                columns: new[] { "MallId", "Location", "Name" },
                values: new object[] { new Guid("93e76def-bc62-4d98-b8df-dd0db1bde1b1"), "10 Pandora", "Ocean Plaza" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Location", "MallId", "Name", "Profit" },
                values: new object[] { new Guid("59389afe-fadc-4ff9-8444-2a8229493f2f"), "10 Pandora", new Guid("93e76def-bc62-4d98-b8df-dd0db1bde1b1"), "Shields and Weapons", 0.0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "StoreId" },
                values: new object[] { new Guid("4070e7cf-2031-4cdf-b717-4a8a1e920211"), 0, new Guid("59389afe-fadc-4ff9-8444-2a8229493f2f") });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "StoreId" },
                values: new object[] { new Guid("48efc935-75d1-4ea2-acc6-9b714d840e6b"), 1, new Guid("59389afe-fadc-4ff9-8444-2a8229493f2f") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Name", "Price", "ProductStatus" },
                values: new object[,]
                {
                    { new Guid("d057fe51-7e85-4c0b-b93b-1b6e2486c0da"), new Guid("4070e7cf-2031-4cdf-b717-4a8a1e920211"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("7472f9d4-2690-4609-9805-aeb8c8e2fc95"), new Guid("4070e7cf-2031-4cdf-b717-4a8a1e920211"), "HP 450 G2", 30000.0, 0 },
                    { new Guid("0a41808e-9372-4a3d-b356-b2ebd84b0cac"), new Guid("4070e7cf-2031-4cdf-b717-4a8a1e920211"), "HP 450 G3", 40000.0, 0 },
                    { new Guid("6bf0fa12-8203-4ee2-9fa1-077249160217"), new Guid("4070e7cf-2031-4cdf-b717-4a8a1e920211"), "HP 450 G4", 50000.0, 0 },
                    { new Guid("f28e6661-4660-435a-9844-f48876eb1f6a"), new Guid("4070e7cf-2031-4cdf-b717-4a8a1e920211"), "HP 850 G5", 60000.0, 0 },
                    { new Guid("f8aa8864-3ab4-4eb1-8b11-f314630e5095"), new Guid("4070e7cf-2031-4cdf-b717-4a8a1e920211"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("4e826afe-2a39-44bf-8d23-2c1937683ee8"), new Guid("4070e7cf-2031-4cdf-b717-4a8a1e920211"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("02050091-d396-4141-ae44-92420824508b"), new Guid("4070e7cf-2031-4cdf-b717-4a8a1e920211"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("18220fe0-8c91-4fdf-a34e-6614dd80037d"), new Guid("4070e7cf-2031-4cdf-b717-4a8a1e920211"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("f375c517-bae8-4d9d-b078-0a59869772b2"), new Guid("48efc935-75d1-4ea2-acc6-9b714d840e6b"), "LogTech G12", 1000.0, 0 },
                    { new Guid("7d9b492a-de0a-4271-a980-53876b3bcef7"), new Guid("48efc935-75d1-4ea2-acc6-9b714d840e6b"), "X7", 2000.0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_StoreId",
                table: "Categories",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_MallId",
                table: "Stores",
                column: "MallId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Malls");
        }
    }
}
