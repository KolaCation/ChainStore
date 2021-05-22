using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ChainStore.DataAccessLayerImpl.Migrations
{
    public partial class DbStructureRework : Migration
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
                    Name = table.Column<string>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "StoreCategoryRelation",
                columns: table => new
                {
                    StoreDbModelId = table.Column<Guid>(nullable: false),
                    CategoryDbModelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreCategoryRelation", x => new { x.StoreDbModelId, x.CategoryDbModelId });
                    table.ForeignKey(
                        name: "FK_StoreCategoryRelation_Categories_CategoryDbModelId",
                        column: x => x.CategoryDbModelId,
                        principalTable: "Categories",
                        principalColumn: "CategoryDbModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreCategoryRelation_Stores_StoreDbModelId",
                        column: x => x.StoreDbModelId,
                        principalTable: "Stores",
                        principalColumn: "StoreDbModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreProductRelation",
                columns: table => new
                {
                    StoreDbModelId = table.Column<Guid>(nullable: false),
                    ProductDbModelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreProductRelation", x => new { x.StoreDbModelId, x.ProductDbModelId });
                    table.ForeignKey(
                        name: "FK_StoreProductRelation_Products_ProductDbModelId",
                        column: x => x.ProductDbModelId,
                        principalTable: "Products",
                        principalColumn: "ProductDbModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreProductRelation_Stores_StoreDbModelId",
                        column: x => x.StoreDbModelId,
                        principalTable: "Stores",
                        principalColumn: "StoreDbModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryDbModelId", "Name", "StoreDbModelId" },
                values: new object[,]
                {
                    { new Guid("bdc0bc96-a4df-40ea-aeb9-199e633c31e0"), "Laptop", null },
                    { new Guid("0b7c1794-ddd8-4fd6-a5a6-68ac9d13f618"), "Mouse", null },
                    { new Guid("59752d04-3a1e-4833-9eb9-f0d274da76b0"), "USB", null }
                });

            migrationBuilder.InsertData(
                table: "Malls",
                columns: new[] { "MallDbModelId", "Location", "Name" },
                values: new object[] { new Guid("57817fa9-88dc-4c4e-abb2-26e0b1d2ed9a"), "10 Pandora Street", "Ocean Plaza" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductDbModelId", "CategoryDbModelId", "Name", "PriceInUAH", "ProductStatus" },
                values: new object[,]
                {
                    { new Guid("c0a047de-d55c-4199-aa7e-68f4d6c4073a"), new Guid("bdc0bc96-a4df-40ea-aeb9-199e633c31e0"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("b3cb63d7-83ce-4de5-a137-c98e8f3feaed"), new Guid("bdc0bc96-a4df-40ea-aeb9-199e633c31e0"), "HP 450 G2", 30000.0, 0 },
                    { new Guid("96fbdc34-e7df-408b-8c70-9bd99c3d855d"), new Guid("bdc0bc96-a4df-40ea-aeb9-199e633c31e0"), "HP 450 G3", 40000.0, 0 },
                    { new Guid("8bee4fd0-8716-4f52-8069-2a1fd66978a1"), new Guid("bdc0bc96-a4df-40ea-aeb9-199e633c31e0"), "HP 450 G4", 50000.0, 0 },
                    { new Guid("3dfa0460-37f0-4892-9715-770e596391eb"), new Guid("bdc0bc96-a4df-40ea-aeb9-199e633c31e0"), "HP 850 G5", 60000.0, 0 },
                    { new Guid("b29787ec-7169-4d27-83aa-238388a582a7"), new Guid("bdc0bc96-a4df-40ea-aeb9-199e633c31e0"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("485e099d-10bb-406f-8394-0333d22421d1"), new Guid("bdc0bc96-a4df-40ea-aeb9-199e633c31e0"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("0667a62e-5b5c-4d92-b569-fa9a1e4f4077"), new Guid("bdc0bc96-a4df-40ea-aeb9-199e633c31e0"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("e05d35c8-f8b7-48c5-9e13-2d4b59b2d73e"), new Guid("bdc0bc96-a4df-40ea-aeb9-199e633c31e0"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("bd3686c9-13a8-47a6-a33c-9d8794eda51b"), new Guid("0b7c1794-ddd8-4fd6-a5a6-68ac9d13f618"), "LogTech G12", 1000.0, 0 },
                    { new Guid("10868013-4ed5-4a89-8b00-7c662e44cfd7"), new Guid("0b7c1794-ddd8-4fd6-a5a6-68ac9d13f618"), "X7", 2000.0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreDbModelId", "Location", "MallDbModelId", "Name", "Profit" },
                values: new object[] { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), "10 Pandora Street", new Guid("57817fa9-88dc-4c4e-abb2-26e0b1d2ed9a"), "Shields and Weapons", 0.0 });

            migrationBuilder.InsertData(
                table: "StoreCategoryRelation",
                columns: new[] { "StoreDbModelId", "CategoryDbModelId" },
                values: new object[,]
                {
                    { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("bdc0bc96-a4df-40ea-aeb9-199e633c31e0") },
                    { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("0b7c1794-ddd8-4fd6-a5a6-68ac9d13f618") }
                });

            migrationBuilder.InsertData(
                table: "StoreProductRelation",
                columns: new[] { "StoreDbModelId", "ProductDbModelId" },
                values: new object[,]
                {
                    { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("c0a047de-d55c-4199-aa7e-68f4d6c4073a") },
                    { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("b29787ec-7169-4d27-83aa-238388a582a7") },
                    { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("485e099d-10bb-406f-8394-0333d22421d1") },
                    { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("0667a62e-5b5c-4d92-b569-fa9a1e4f4077") },
                    { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("e05d35c8-f8b7-48c5-9e13-2d4b59b2d73e") },
                    { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("b3cb63d7-83ce-4de5-a137-c98e8f3feaed") },
                    { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("96fbdc34-e7df-408b-8c70-9bd99c3d855d") },
                    { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("8bee4fd0-8716-4f52-8069-2a1fd66978a1") },
                    { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("3dfa0460-37f0-4892-9715-770e596391eb") },
                    { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("bd3686c9-13a8-47a6-a33c-9d8794eda51b") },
                    { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("10868013-4ed5-4a89-8b00-7c662e44cfd7") }
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
                name: "IX_StoreCategoryRelation_CategoryDbModelId",
                table: "StoreCategoryRelation",
                column: "CategoryDbModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProductRelation_ProductDbModelId",
                table: "StoreProductRelation",
                column: "ProductDbModelId");

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
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "StoreCategoryRelation");

            migrationBuilder.DropTable(
                name: "StoreProductRelation");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Malls");
        }
    }
}
