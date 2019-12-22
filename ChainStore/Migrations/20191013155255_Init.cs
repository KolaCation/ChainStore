using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStore.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    IsSubStore = table.Column<bool>(nullable: false),
                    Profit = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => new { x.ClientId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Purchases_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    CategoryName = table.Column<int>(nullable: false),
                    StoreId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Clients",
                columns: new[] { "ClientId", "Balance", "Name" },
                values: new object[] { new Guid("942df19c-69aa-4a82-9a48-5925b5021e28"), 0.0, "John" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Balance", "Name" },
                values: new object[] { new Guid("a70b6202-2d33-4816-b0d4-e2a10fd65bfa"), 0.0, "Wil" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "IsSubStore", "Location", "Name", "Profit" },
                values: new object[] { new Guid("3957a423-9d61-49b9-9f94-2cbdc65f678d"), false, "10 Pandora", "Shields and Weapons", 0.0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "StoreId" },
                values: new object[,]
                {
                    { new Guid("268b16f9-d580-406b-82ee-2ca75518f80d"), 0, new Guid("3957a423-9d61-49b9-9f94-2cbdc65f678d") },
                    { new Guid("3ecae22f-4537-4448-bd0c-50878d76fc4c"), 1, new Guid("3957a423-9d61-49b9-9f94-2cbdc65f678d") }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "ClientId", "ProductId" },
                values: new object[,]
                {
                    { new Guid("942df19c-69aa-4a82-9a48-5925b5021e28"), new Guid("bfdde67c-babf-40f2-a5bb-118cd8c0bec5") },
                    { new Guid("942df19c-69aa-4a82-9a48-5925b5021e28"), new Guid("3b0cbece-631e-4e11-9e2e-a686d7ae87a5") },
                    { new Guid("942df19c-69aa-4a82-9a48-5925b5021e28"), new Guid("80c90ba1-022d-436d-9d99-eb7d60038461") },
                    { new Guid("a70b6202-2d33-4816-b0d4-e2a10fd65bfa"), new Guid("8c2a1f32-276c-47c6-9638-a897d44ac8f5") },
                    { new Guid("a70b6202-2d33-4816-b0d4-e2a10fd65bfa"), new Guid("7def4192-8577-4e04-92ed-448c40999f41") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Name", "Price", "ProductStatus" },
                values: new object[,]
                {
                    { new Guid("bfdde67c-babf-40f2-a5bb-118cd8c0bec5"), new Guid("268b16f9-d580-406b-82ee-2ca75518f80d"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("3b0cbece-631e-4e11-9e2e-a686d7ae87a5"), new Guid("268b16f9-d580-406b-82ee-2ca75518f80d"), "HP 450 G2", 30000.0, 0 },
                    { new Guid("80c90ba1-022d-436d-9d99-eb7d60038461"), new Guid("268b16f9-d580-406b-82ee-2ca75518f80d"), "HP 450 G3", 40000.0, 0 },
                    { new Guid("3e0a2251-46ba-4303-8bcc-72ec000ea855"), new Guid("268b16f9-d580-406b-82ee-2ca75518f80d"), "HP 450 G4", 50000.0, 0 },
                    { new Guid("8c2a1f32-276c-47c6-9638-a897d44ac8f5"), new Guid("268b16f9-d580-406b-82ee-2ca75518f80d"), "HP 850 G5", 60000.0, 0 },
                    { new Guid("7def4192-8577-4e04-92ed-448c40999f41"), new Guid("3ecae22f-4537-4448-bd0c-50878d76fc4c"), "LogTech G12", 1000.0, 0 },
                    { new Guid("bf56541d-d56b-4fd5-8073-5b4893d75087"), new Guid("3ecae22f-4537-4448-bd0c-50878d76fc4c"), "X7", 2000.0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_StoreId",
                table: "Categories",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
