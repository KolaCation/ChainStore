using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStore.Migrations
{
    public partial class Setup2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("3b0cbece-631e-4e11-9e2e-a686d7ae87a5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("3e0a2251-46ba-4303-8bcc-72ec000ea855"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("7def4192-8577-4e04-92ed-448c40999f41"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("80c90ba1-022d-436d-9d99-eb7d60038461"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("8c2a1f32-276c-47c6-9638-a897d44ac8f5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("bf56541d-d56b-4fd5-8073-5b4893d75087"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("bfdde67c-babf-40f2-a5bb-118cd8c0bec5"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumns: new[] { "ClientId", "ProductId" },
                keyValues: new object[] { new Guid("942df19c-69aa-4a82-9a48-5925b5021e28"), new Guid("3b0cbece-631e-4e11-9e2e-a686d7ae87a5") });

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumns: new[] { "ClientId", "ProductId" },
                keyValues: new object[] { new Guid("942df19c-69aa-4a82-9a48-5925b5021e28"), new Guid("80c90ba1-022d-436d-9d99-eb7d60038461") });

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumns: new[] { "ClientId", "ProductId" },
                keyValues: new object[] { new Guid("942df19c-69aa-4a82-9a48-5925b5021e28"), new Guid("bfdde67c-babf-40f2-a5bb-118cd8c0bec5") });

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumns: new[] { "ClientId", "ProductId" },
                keyValues: new object[] { new Guid("a70b6202-2d33-4816-b0d4-e2a10fd65bfa"), new Guid("7def4192-8577-4e04-92ed-448c40999f41") });

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumns: new[] { "ClientId", "ProductId" },
                keyValues: new object[] { new Guid("a70b6202-2d33-4816-b0d4-e2a10fd65bfa"), new Guid("8c2a1f32-276c-47c6-9638-a897d44ac8f5") });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("268b16f9-d580-406b-82ee-2ca75518f80d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("3ecae22f-4537-4448-bd0c-50878d76fc4c"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("942df19c-69aa-4a82-9a48-5925b5021e28"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("a70b6202-2d33-4816-b0d4-e2a10fd65bfa"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: new Guid("3957a423-9d61-49b9-9f94-2cbdc65f678d"));

            migrationBuilder.DropColumn(
                name: "IsSubStore",
                table: "Stores");

            migrationBuilder.AddColumn<Guid>(
                name: "MallId",
                table: "Stores",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PurchaseId",
                table: "Purchases",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreationTime",
                table: "Purchases",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                column: "PurchaseId");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                    table.ForeignKey(
                        name: "FK_Books_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Balance", "Name" },
                values: new object[] { new Guid("a3a20ad9-599c-4800-b1df-c7446feaccef"), 0.0, "John" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Balance", "Name" },
                values: new object[] { new Guid("c1cd4efe-11e8-47be-a4dd-9d460cc3087f"), 0.0, "Wil" });

            migrationBuilder.InsertData(
                table: "Malls",
                columns: new[] { "MallId", "Location", "Name" },
                values: new object[] { new Guid("b5764cc4-b1c3-4ba1-ac04-be3b8bf637ce"), "10 Pandora", "Ocean Plaza" });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "PurchaseId", "ClientId", "CreationTime", "ProductId" },
                values: new object[,]
                {
                    { new Guid("b0c671a4-3d4b-4095-a712-f080220b51ba"), new Guid("a3a20ad9-599c-4800-b1df-c7446feaccef"), new DateTimeOffset(new DateTime(2019, 10, 18, 21, 35, 48, 571, DateTimeKind.Unspecified).AddTicks(6), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a3fe5687-5a1e-47a7-b5ca-6f9d0867f9cc") },
                    { new Guid("ea1f9f14-f50d-4aae-bc40-1061b7d00b8b"), new Guid("a3a20ad9-599c-4800-b1df-c7446feaccef"), new DateTimeOffset(new DateTime(2019, 10, 18, 21, 35, 48, 571, DateTimeKind.Unspecified).AddTicks(1548), new TimeSpan(0, 0, 0, 0, 0)), new Guid("de2d5b56-1619-4a67-a001-8102919241b9") },
                    { new Guid("1b89994a-c08a-4ad4-af22-bfdbad2ef4d7"), new Guid("a3a20ad9-599c-4800-b1df-c7446feaccef"), new DateTimeOffset(new DateTime(2019, 10, 18, 21, 35, 48, 571, DateTimeKind.Unspecified).AddTicks(1575), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d7ef6e05-99aa-43d1-87d7-efb6e086a3f0") },
                    { new Guid("44fedda1-4ebd-43dd-a1a6-faba99702369"), new Guid("c1cd4efe-11e8-47be-a4dd-9d460cc3087f"), new DateTimeOffset(new DateTime(2019, 10, 18, 21, 35, 48, 571, DateTimeKind.Unspecified).AddTicks(1655), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f195a9cc-b7ef-4936-ae07-fec3ffe1bcac") },
                    { new Guid("138567ac-3fa6-4b7a-bd1c-a8ad322f4589"), new Guid("c1cd4efe-11e8-47be-a4dd-9d460cc3087f"), new DateTimeOffset(new DateTime(2019, 10, 18, 21, 35, 48, 571, DateTimeKind.Unspecified).AddTicks(1659), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7c5b6007-6cf2-41b1-8e7b-77fae2da20b3") }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Location", "MallId", "Name", "Profit" },
                values: new object[] { new Guid("16b35a25-b711-40bb-9ca5-89a50ecaf3ec"), "10 Pandora", new Guid("b5764cc4-b1c3-4ba1-ac04-be3b8bf637ce"), "Shields and Weapons", 0.0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "StoreId" },
                values: new object[] { new Guid("eb54a03d-a746-4f77-9826-7b7f79342ca4"), 0, new Guid("16b35a25-b711-40bb-9ca5-89a50ecaf3ec") });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "StoreId" },
                values: new object[] { new Guid("3e7a0d2c-4b91-487a-81ab-3b90fe5d35bf"), 1, new Guid("16b35a25-b711-40bb-9ca5-89a50ecaf3ec") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Name", "Price", "ProductStatus" },
                values: new object[,]
                {
                    { new Guid("a3fe5687-5a1e-47a7-b5ca-6f9d0867f9cc"), new Guid("eb54a03d-a746-4f77-9826-7b7f79342ca4"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("de2d5b56-1619-4a67-a001-8102919241b9"), new Guid("eb54a03d-a746-4f77-9826-7b7f79342ca4"), "HP 450 G2", 30000.0, 0 },
                    { new Guid("d7ef6e05-99aa-43d1-87d7-efb6e086a3f0"), new Guid("eb54a03d-a746-4f77-9826-7b7f79342ca4"), "HP 450 G3", 40000.0, 0 },
                    { new Guid("21c0a81a-5679-436e-a41f-0b270e6e8daf"), new Guid("eb54a03d-a746-4f77-9826-7b7f79342ca4"), "HP 450 G4", 50000.0, 0 },
                    { new Guid("f195a9cc-b7ef-4936-ae07-fec3ffe1bcac"), new Guid("eb54a03d-a746-4f77-9826-7b7f79342ca4"), "HP 850 G5", 60000.0, 0 },
                    { new Guid("7c5b6007-6cf2-41b1-8e7b-77fae2da20b3"), new Guid("3e7a0d2c-4b91-487a-81ab-3b90fe5d35bf"), "LogTech G12", 1000.0, 0 },
                    { new Guid("add910d7-eaaf-4f9a-88e8-2a8396983833"), new Guid("3e7a0d2c-4b91-487a-81ab-3b90fe5d35bf"), "X7", 2000.0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_MallId",
                table: "Stores",
                column: "MallId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ClientId",
                table: "Purchases",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ClientId",
                table: "Books",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Malls_MallId",
                table: "Stores",
                column: "MallId",
                principalTable: "Malls",
                principalColumn: "MallId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Malls_MallId",
                table: "Stores");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Malls");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Stores_MallId",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_ClientId",
                table: "Purchases");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("21c0a81a-5679-436e-a41f-0b270e6e8daf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("7c5b6007-6cf2-41b1-8e7b-77fae2da20b3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a3fe5687-5a1e-47a7-b5ca-6f9d0867f9cc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("add910d7-eaaf-4f9a-88e8-2a8396983833"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d7ef6e05-99aa-43d1-87d7-efb6e086a3f0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("de2d5b56-1619-4a67-a001-8102919241b9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("f195a9cc-b7ef-4936-ae07-fec3ffe1bcac"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("138567ac-3fa6-4b7a-bd1c-a8ad322f4589"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("1b89994a-c08a-4ad4-af22-bfdbad2ef4d7"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("44fedda1-4ebd-43dd-a1a6-faba99702369"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("b0c671a4-3d4b-4095-a712-f080220b51ba"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("ea1f9f14-f50d-4aae-bc40-1061b7d00b8b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("3e7a0d2c-4b91-487a-81ab-3b90fe5d35bf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("eb54a03d-a746-4f77-9826-7b7f79342ca4"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("a3a20ad9-599c-4800-b1df-c7446feaccef"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("c1cd4efe-11e8-47be-a4dd-9d460cc3087f"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: new Guid("16b35a25-b711-40bb-9ca5-89a50ecaf3ec"));

            migrationBuilder.DropColumn(
                name: "MallId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Purchases");

            migrationBuilder.AddColumn<bool>(
                name: "IsSubStore",
                table: "Stores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                columns: new[] { "ClientId", "ProductId" });

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
        }
    }
}
