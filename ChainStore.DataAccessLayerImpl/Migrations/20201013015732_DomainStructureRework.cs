using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStore.DataAccessLayerImpl.Migrations
{
    public partial class DomainStructureRework : Migration
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
                name: "StoreCategoryDbModels",
                columns: table => new
                {
                    StoreId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    StoreDbModelId = table.Column<Guid>(nullable: true),
                    CategoryDbModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreCategoryDbModels", x => new { x.StoreId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_StoreCategoryDbModels_Categories_CategoryDbModelId",
                        column: x => x.CategoryDbModelId,
                        principalTable: "Categories",
                        principalColumn: "CategoryDbModelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreCategoryDbModels_Stores_StoreDbModelId",
                        column: x => x.StoreDbModelId,
                        principalTable: "Stores",
                        principalColumn: "StoreDbModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreProductDbModels",
                columns: table => new
                {
                    StoreId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    StoreDbModelId = table.Column<Guid>(nullable: true),
                    ProductDbModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreProductDbModels", x => new { x.StoreId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_StoreProductDbModels_Products_ProductDbModelId",
                        column: x => x.ProductDbModelId,
                        principalTable: "Products",
                        principalColumn: "ProductDbModelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreProductDbModels_Stores_StoreDbModelId",
                        column: x => x.StoreDbModelId,
                        principalTable: "Stores",
                        principalColumn: "StoreDbModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryDbModelId", "Name", "StoreDbModelId" },
                values: new object[,]
                {
                    { new Guid("79454a4e-76e9-44fd-bf24-01f86fcf5db4"), "Laptop", null },
                    { new Guid("dcb0af0c-45e5-400f-b10f-ff4e071ed904"), "Mouse", null }
                });

            migrationBuilder.InsertData(
                table: "Malls",
                columns: new[] { "MallDbModelId", "Location", "Name" },
                values: new object[] { new Guid("c4570f80-3d01-4bb8-bdef-ce87b29c69a6"), "10 Pandora Street", "Ocean Plaza" });

            migrationBuilder.InsertData(
                table: "StoreCategoryDbModels",
                columns: new[] { "StoreId", "CategoryId", "CategoryDbModelId", "StoreDbModelId" },
                values: new object[,]
                {
                    { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("79454a4e-76e9-44fd-bf24-01f86fcf5db4"), null, null },
                    { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("dcb0af0c-45e5-400f-b10f-ff4e071ed904"), null, null }
                });

            migrationBuilder.InsertData(
                table: "StoreProductDbModels",
                columns: new[] { "StoreId", "ProductId", "ProductDbModelId", "StoreDbModelId" },
                values: new object[,]
                {
                    { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("f0228d9a-2050-4e4c-979f-413103c703ae"), null, null },
                    { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("c9930aba-d5f2-42a5-a1a8-5893bcaf7e12"), null, null },
                    { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("b9d1bdcc-ddf2-4b21-99b6-993773e33432"), null, null },
                    { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("dc136d9b-a826-433a-8687-acd6dd6141c1"), null, null },
                    { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("fed28943-0fa6-48c5-9e4a-add9e9040af5"), null, null },
                    { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("c6ee5f31-3354-448d-b26c-4111406365ec"), null, null },
                    { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("78ca4154-a904-48fe-a4c5-fa7e23020729"), null, null },
                    { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("e6b96cf1-9952-49b7-9148-7492f1f02d76"), null, null },
                    { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("f1e5b4b5-876f-4d1a-be99-a0cff31c055b"), null, null },
                    { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("4f2b7566-f5d3-496e-9549-b9e84e5f9fb4"), null, null },
                    { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("c8d32a25-8039-4852-8164-35fdb1c6a6b5"), null, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductDbModelId", "CategoryDbModelId", "Name", "PriceInUAH", "ProductStatus" },
                values: new object[,]
                {
                    { new Guid("f0228d9a-2050-4e4c-979f-413103c703ae"), new Guid("79454a4e-76e9-44fd-bf24-01f86fcf5db4"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("c6ee5f31-3354-448d-b26c-4111406365ec"), new Guid("79454a4e-76e9-44fd-bf24-01f86fcf5db4"), "HP 450 G2", 30000.0, 0 },
                    { new Guid("78ca4154-a904-48fe-a4c5-fa7e23020729"), new Guid("79454a4e-76e9-44fd-bf24-01f86fcf5db4"), "HP 450 G3", 40000.0, 0 },
                    { new Guid("e6b96cf1-9952-49b7-9148-7492f1f02d76"), new Guid("79454a4e-76e9-44fd-bf24-01f86fcf5db4"), "HP 450 G4", 50000.0, 0 },
                    { new Guid("f1e5b4b5-876f-4d1a-be99-a0cff31c055b"), new Guid("79454a4e-76e9-44fd-bf24-01f86fcf5db4"), "HP 850 G5", 60000.0, 0 },
                    { new Guid("c9930aba-d5f2-42a5-a1a8-5893bcaf7e12"), new Guid("79454a4e-76e9-44fd-bf24-01f86fcf5db4"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("b9d1bdcc-ddf2-4b21-99b6-993773e33432"), new Guid("79454a4e-76e9-44fd-bf24-01f86fcf5db4"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("dc136d9b-a826-433a-8687-acd6dd6141c1"), new Guid("79454a4e-76e9-44fd-bf24-01f86fcf5db4"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("fed28943-0fa6-48c5-9e4a-add9e9040af5"), new Guid("79454a4e-76e9-44fd-bf24-01f86fcf5db4"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("4f2b7566-f5d3-496e-9549-b9e84e5f9fb4"), new Guid("dcb0af0c-45e5-400f-b10f-ff4e071ed904"), "LogTech G12", 1000.0, 0 },
                    { new Guid("c8d32a25-8039-4852-8164-35fdb1c6a6b5"), new Guid("dcb0af0c-45e5-400f-b10f-ff4e071ed904"), "X7", 2000.0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreDbModelId", "Location", "MallDbModelId", "Name", "Profit" },
                values: new object[] { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), "10 Pandora Street", new Guid("c4570f80-3d01-4bb8-bdef-ce87b29c69a6"), "Shields and Weapons", 0.0 });

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
                name: "IX_StoreCategoryDbModels_CategoryDbModelId",
                table: "StoreCategoryDbModels",
                column: "CategoryDbModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreCategoryDbModels_StoreDbModelId",
                table: "StoreCategoryDbModels",
                column: "StoreDbModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProductDbModels_ProductDbModelId",
                table: "StoreProductDbModels",
                column: "ProductDbModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProductDbModels_StoreDbModelId",
                table: "StoreProductDbModels",
                column: "StoreDbModelId");

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
                name: "StoreCategoryDbModels");

            migrationBuilder.DropTable(
                name: "StoreProductDbModels");

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
