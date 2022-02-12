using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace ChainStore.DataAccessLayerImpl.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerDbModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ExpirationTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ReserveDaysCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CashBackPercent = table.Column<int>(type: "int", nullable: true),
                    CashBack = table.Column<double>(type: "float", nullable: true),
                    DiscountPercent = table.Column<int>(type: "int", nullable: true),
                    Points = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Malls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PriceAtPurchaseMoment = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MallId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Profit = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Malls_MallId",
                        column: x => x.MallId,
                        principalTable: "Malls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreDbModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Stores_StoreDbModelId",
                        column: x => x.StoreDbModelId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceInUAH = table.Column<double>(type: "float", nullable: false),
                    ProductStatus = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreCategoryRelation",
                columns: table => new
                {
                    StoreDbModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryDbModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreCategoryRelation", x => new { x.StoreDbModelId, x.CategoryDbModelId });
                    table.ForeignKey(
                        name: "FK_StoreCategoryRelation_Categories_CategoryDbModelId",
                        column: x => x.CategoryDbModelId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreCategoryRelation_Stores_StoreDbModelId",
                        column: x => x.StoreDbModelId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreProductRelation",
                columns: table => new
                {
                    StoreDbModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductDbModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreProductRelation", x => new { x.StoreDbModelId, x.ProductDbModelId });
                    table.ForeignKey(
                        name: "FK_StoreProductRelation_Products_ProductDbModelId",
                        column: x => x.ProductDbModelId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreProductRelation_Stores_StoreDbModelId",
                        column: x => x.StoreDbModelId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "StoreDbModelId" },
                values: new object[,]
                {
                    { new Guid("0f798ee0-a067-4c46-9018-76cddb083949"), "USB", null },
                    { new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"), "Laptop", null },
                    { new Guid("cb454cdf-7b81-4bb3-84b1-a2958a272213"), "Mouse", null }
                });

            migrationBuilder.InsertData(
                table: "Malls",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[] { new Guid("d51f2f67-ad25-435c-b9fc-20646cb53936"), "10 Pandora Street", "Ocean Plaza" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "PriceInUAH", "ProductStatus" },
                values: new object[,]
                {
                    { new Guid("1c1641b0-9b16-40a6-8ec2-5a63eb26ea0e"), new Guid("cb454cdf-7b81-4bb3-84b1-a2958a272213"), "X7", 2000.0, 0 },
                    { new Guid("386a2632-0827-4fac-84fb-9a1baf7b1d56"), new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"), "HP 450 G4", 50000.0, 0 },
                    { new Guid("4cd83e2e-6afa-4436-8e90-8e6a0d00a9c5"), new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("5beb03eb-6415-4819-8131-6b6e3ecd0bcf"), new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("99e42cde-7987-4d81-9be9-7777b64bba27"), new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("b1f5345c-61f1-43fe-99c6-1708aea98ce1"), new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("bd44ac0d-cf07-410c-ab19-7ef9cf220cbd"), new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"), "HP 450 G3", 40000.0, 0 },
                    { new Guid("c34e803f-9c5c-4fae-a2bf-6a935070609c"), new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"), "HP 850 G5", 60000.0, 0 },
                    { new Guid("cbde0e36-b669-4991-8c21-0def6606ef6f"), new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"), "HP 450 G2", 30000.0, 0 },
                    { new Guid("d7a9084e-6259-4fa2-92ee-6aa24c489d3c"), new Guid("cb454cdf-7b81-4bb3-84b1-a2958a272213"), "LogTech G12", 1000.0, 0 },
                    { new Guid("e09ed0c8-ffd3-4b12-9dc8-302be4f94748"), new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"), "HP 450 G1", 20000.0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Location", "MallId", "Name", "Profit" },
                values: new object[] { new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0"), "10 Pandora Street", new Guid("d51f2f67-ad25-435c-b9fc-20646cb53936"), "Shields and Weapons", 0.0 });

            migrationBuilder.InsertData(
                table: "StoreCategoryRelation",
                columns: new[] { "CategoryDbModelId", "StoreDbModelId" },
                values: new object[,]
                {
                    { new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"), new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0") },
                    { new Guid("cb454cdf-7b81-4bb3-84b1-a2958a272213"), new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0") }
                });

            migrationBuilder.InsertData(
                table: "StoreProductRelation",
                columns: new[] { "ProductDbModelId", "StoreDbModelId" },
                values: new object[,]
                {
                    { new Guid("1c1641b0-9b16-40a6-8ec2-5a63eb26ea0e"), new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0") },
                    { new Guid("386a2632-0827-4fac-84fb-9a1baf7b1d56"), new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0") },
                    { new Guid("4cd83e2e-6afa-4436-8e90-8e6a0d00a9c5"), new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0") },
                    { new Guid("5beb03eb-6415-4819-8131-6b6e3ecd0bcf"), new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0") },
                    { new Guid("99e42cde-7987-4d81-9be9-7777b64bba27"), new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0") },
                    { new Guid("b1f5345c-61f1-43fe-99c6-1708aea98ce1"), new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0") },
                    { new Guid("bd44ac0d-cf07-410c-ab19-7ef9cf220cbd"), new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0") },
                    { new Guid("c34e803f-9c5c-4fae-a2bf-6a935070609c"), new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0") },
                    { new Guid("cbde0e36-b669-4991-8c21-0def6606ef6f"), new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0") },
                    { new Guid("d7a9084e-6259-4fa2-92ee-6aa24c489d3c"), new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0") },
                    { new Guid("e09ed0c8-ffd3-4b12-9dc8-302be4f94748"), new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0") }
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
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreCategoryRelation_CategoryDbModelId",
                table: "StoreCategoryRelation",
                column: "CategoryDbModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProductRelation_ProductDbModelId",
                table: "StoreProductRelation",
                column: "ProductDbModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_MallId",
                table: "Stores",
                column: "MallId");
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
                name: "Customers");

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
