using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStore.DataAccessLayerImpl.Migrations
{
    public partial class InitVer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ClientDbModelId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookDbModelId = table.Column<Guid>(nullable: false),
                    ClientDbModelId = table.Column<Guid>(nullable: false),
                    ProductDbModelId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false),
                    ExpirationTime = table.Column<DateTimeOffset>(nullable: false),
                    ReserveDaysCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookDbModelId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientDbModelId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Balance = table.Column<double>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    CashBackPercent = table.Column<int>(nullable: true),
                    CashBack = table.Column<double>(nullable: true),
                    DiscountPercent = table.Column<int>(nullable: true),
                    Points = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientDbModelId);
                });

            migrationBuilder.CreateTable(
                name: "Malls",
                columns: table => new
                {
                    MallDbModelId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malls", x => x.MallDbModelId);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseDbModelId = table.Column<Guid>(nullable: false),
                    ClientDbModelId = table.Column<Guid>(nullable: false),
                    ProductDbModelId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseDbModelId);
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

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreDbModelId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    MallDbModelId = table.Column<Guid>(nullable: true),
                    Profit = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreDbModelId);
                    table.ForeignKey(
                        name: "FK_Stores_Malls_MallDbModelId",
                        column: x => x.MallDbModelId,
                        principalTable: "Malls",
                        principalColumn: "MallDbModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryDbModelId = table.Column<Guid>(nullable: false),
                    CategoryName = table.Column<int>(nullable: false),
                    StoreDbModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryDbModelId);
                    table.ForeignKey(
                        name: "FK_Categories_Stores_StoreDbModelId",
                        column: x => x.StoreDbModelId,
                        principalTable: "Stores",
                        principalColumn: "StoreDbModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductDbModelId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PriceInUAH = table.Column<double>(nullable: false),
                    ProductStatus = table.Column<int>(nullable: false),
                    CategoryDbModelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductDbModelId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryDbModelId",
                        column: x => x.CategoryDbModelId,
                        principalTable: "Categories",
                        principalColumn: "CategoryDbModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Malls",
                columns: new[] { "MallDbModelId", "Location", "Name" },
                values: new object[] { new Guid("5f6b7f84-4356-4744-acaa-7bedc42f7af8"), "10 Pandora", "Ocean Plaza" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreDbModelId", "Location", "MallDbModelId", "Name", "Profit" },
                values: new object[] { new Guid("c1365d87-8cc4-4431-8d06-e2ae488dd393"), "10 Pandora", new Guid("5f6b7f84-4356-4744-acaa-7bedc42f7af8"), "Shields and Weapons", 0.0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryDbModelId", "CategoryName", "StoreDbModelId" },
                values: new object[] { new Guid("410932bc-5d6a-4640-9dbb-6bea9f6b3132"), 0, new Guid("c1365d87-8cc4-4431-8d06-e2ae488dd393") });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryDbModelId", "CategoryName", "StoreDbModelId" },
                values: new object[] { new Guid("3fd35f16-6ffc-4815-9f5c-780f27e4389f"), 1, new Guid("c1365d87-8cc4-4431-8d06-e2ae488dd393") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductDbModelId", "CategoryDbModelId", "Name", "PriceInUAH", "ProductStatus" },
                values: new object[,]
                {
                    { new Guid("5b03edbb-d10f-4d65-8f78-9cf911568874"), new Guid("410932bc-5d6a-4640-9dbb-6bea9f6b3132"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("84a06b03-f901-4d94-a7f4-3f0ffe14183e"), new Guid("410932bc-5d6a-4640-9dbb-6bea9f6b3132"), "HP 450 G2", 30000.0, 0 },
                    { new Guid("37da1f79-0e9d-450f-8008-73573378f02f"), new Guid("410932bc-5d6a-4640-9dbb-6bea9f6b3132"), "HP 450 G3", 40000.0, 0 },
                    { new Guid("25031440-afbb-4147-8c82-621c8f810bd7"), new Guid("410932bc-5d6a-4640-9dbb-6bea9f6b3132"), "HP 450 G4", 50000.0, 0 },
                    { new Guid("6664e6cf-5e47-43f9-95e3-10d4fa91289a"), new Guid("410932bc-5d6a-4640-9dbb-6bea9f6b3132"), "HP 850 G5", 60000.0, 0 },
                    { new Guid("44e0bbc7-2100-469b-82fe-c61c65667199"), new Guid("410932bc-5d6a-4640-9dbb-6bea9f6b3132"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("94baf082-5ee9-40dc-85ed-3a91781ae49d"), new Guid("410932bc-5d6a-4640-9dbb-6bea9f6b3132"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("73786d11-99ad-4c5a-9e29-f76765e854fa"), new Guid("410932bc-5d6a-4640-9dbb-6bea9f6b3132"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("263b4c21-f8bd-4e2a-9a41-a0e252f5d6c3"), new Guid("410932bc-5d6a-4640-9dbb-6bea9f6b3132"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("413b7a88-bc69-43a3-9c21-b6e6565b6798"), new Guid("3fd35f16-6ffc-4815-9f5c-780f27e4389f"), "LogTech G12", 1000.0, 0 },
                    { new Guid("ca30f970-eea9-4a69-83a7-420bfce2152d"), new Guid("3fd35f16-6ffc-4815-9f5c-780f27e4389f"), "X7", 2000.0, 0 }
                });

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
                name: "IX_Categories_StoreDbModelId",
                table: "Categories",
                column: "StoreDbModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryDbModelId",
                table: "Products",
                column: "CategoryDbModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_MallDbModelId",
                table: "Stores",
                column: "MallDbModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Malls");
        }
    }
}
