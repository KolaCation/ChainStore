using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStore.Migrations
{
    public partial class Setup3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Clients_ClientId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Clients_ClientId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_ClientId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Books_ClientId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("14971105-760a-49d6-bc68-c30de6e02e71"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("223c59e6-9fdb-4bc2-b66c-b41cd3f7c69e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("4f5a3548-99c2-4672-8401-23da19d86249"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("55acc017-e909-44dd-a390-30427b070d5c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("7d5dd5d3-2d71-47de-a75c-f28ddc71f602"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("85bdd2c1-b3bf-4a5d-a7e2-6e38cfc0b01c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("8baca7be-82bb-4783-867c-4cde41d5bf4e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("ccd9ff91-423e-4f20-a319-4abd11b74432"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d455fca1-756c-4df8-bab8-6bc63c6803ef"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d4e5b838-9737-4f31-9bf1-d311b048480d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("e4ef194c-bace-4b45-9503-65bb11f1c392"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("1cf4afba-712e-4325-9900-5b6c92ef009e"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("89b95ec5-7c71-4659-af50-1fc4927f8e88"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("a2230174-ee2f-42fa-9c39-fde2fe09ffe4"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("d1504675-611e-4a72-9089-b481f846f6aa"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("fcff767e-cc06-4e4e-91a5-b84ddc659c9b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("6a2244de-2fb2-4280-8b89-f04ddc8de0fd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("769819e5-4392-4f80-9195-10016ee68b43"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("79c42c02-ce14-43e2-ad0c-ead85c9704f5"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("e6cae852-129f-4d9e-a832-45c068aa7a60"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: new Guid("f80d0f79-bcf7-41d7-8fed-adbaa9854a27"));

            migrationBuilder.DeleteData(
                table: "Malls",
                keyColumn: "MallId",
                keyValue: new Guid("3afa0f14-98ef-4ed4-a96a-ced14c414f88"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Balance", "Name" },
                values: new object[,]
                {
                    { new Guid("79e84cea-0871-408e-91f1-8cde1cf0aeba"), 0.0, "John" },
                    { new Guid("eaf7221f-fd3d-437c-b6bc-a3341c1b932e"), 0.0, "Wil" }
                });

            migrationBuilder.InsertData(
                table: "Malls",
                columns: new[] { "MallId", "Location", "Name" },
                values: new object[] { new Guid("f0c9370e-5a45-47c5-be96-2edd8814a87b"), "10 Pandora", "Ocean Plaza" });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "PurchaseId", "ClientId", "CreationTime", "ProductId" },
                values: new object[,]
                {
                    { new Guid("2d7acfcf-f152-44f2-aea9-91f63779b1ec"), new Guid("79e84cea-0871-408e-91f1-8cde1cf0aeba"), new DateTimeOffset(new DateTime(2019, 10, 30, 8, 55, 16, 41, DateTimeKind.Unspecified).AddTicks(5524), new TimeSpan(0, 0, 0, 0, 0)), new Guid("1fd29202-6998-420d-a5de-c8cb52d697eb") },
                    { new Guid("0ec0c84a-bae8-4a6b-abd6-c2a2695a43b0"), new Guid("79e84cea-0871-408e-91f1-8cde1cf0aeba"), new DateTimeOffset(new DateTime(2019, 10, 30, 8, 55, 16, 41, DateTimeKind.Unspecified).AddTicks(7162), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3e184afc-4062-4466-bf6a-8f3f496db2d3") },
                    { new Guid("3c23cff3-612f-4c2b-9481-de07fda9a6bb"), new Guid("79e84cea-0871-408e-91f1-8cde1cf0aeba"), new DateTimeOffset(new DateTime(2019, 10, 30, 8, 55, 16, 41, DateTimeKind.Unspecified).AddTicks(7230), new TimeSpan(0, 0, 0, 0, 0)), new Guid("9fbd0a46-c9d8-4ff1-a4a7-27b28f41cbe6") },
                    { new Guid("0db888e8-6adb-4479-89de-322b4cb91448"), new Guid("eaf7221f-fd3d-437c-b6bc-a3341c1b932e"), new DateTimeOffset(new DateTime(2019, 10, 30, 8, 55, 16, 41, DateTimeKind.Unspecified).AddTicks(7278), new TimeSpan(0, 0, 0, 0, 0)), new Guid("13f0cd9c-2415-432b-854f-ec4322b21684") },
                    { new Guid("2b3e0698-84b1-4378-8f30-83ab96e3f934"), new Guid("eaf7221f-fd3d-437c-b6bc-a3341c1b932e"), new DateTimeOffset(new DateTime(2019, 10, 30, 8, 55, 16, 41, DateTimeKind.Unspecified).AddTicks(7281), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d46f227b-e5f7-4b35-82f9-ebd6a9da4a04") }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Location", "MallId", "Name", "Profit" },
                values: new object[] { new Guid("339c2339-26b2-484e-98ea-3d28b16149c2"), "10 Pandora", new Guid("f0c9370e-5a45-47c5-be96-2edd8814a87b"), "Shields and Weapons", 0.0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "StoreId" },
                values: new object[] { new Guid("eda4d57f-784f-45f7-8bf9-a27422fd5174"), 0, new Guid("339c2339-26b2-484e-98ea-3d28b16149c2") });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "StoreId" },
                values: new object[] { new Guid("33565a3c-49c3-479b-b878-9adc33216f9e"), 1, new Guid("339c2339-26b2-484e-98ea-3d28b16149c2") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Name", "Price", "ProductStatus" },
                values: new object[,]
                {
                    { new Guid("1fd29202-6998-420d-a5de-c8cb52d697eb"), new Guid("eda4d57f-784f-45f7-8bf9-a27422fd5174"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("3e184afc-4062-4466-bf6a-8f3f496db2d3"), new Guid("eda4d57f-784f-45f7-8bf9-a27422fd5174"), "HP 450 G2", 30000.0, 0 },
                    { new Guid("9fbd0a46-c9d8-4ff1-a4a7-27b28f41cbe6"), new Guid("eda4d57f-784f-45f7-8bf9-a27422fd5174"), "HP 450 G3", 40000.0, 0 },
                    { new Guid("d3c2c316-f108-4bf1-9c00-2815327f2de8"), new Guid("eda4d57f-784f-45f7-8bf9-a27422fd5174"), "HP 450 G4", 50000.0, 0 },
                    { new Guid("13f0cd9c-2415-432b-854f-ec4322b21684"), new Guid("eda4d57f-784f-45f7-8bf9-a27422fd5174"), "HP 850 G5", 60000.0, 0 },
                    { new Guid("a0594777-f449-49db-b9e4-10e0bd40899e"), new Guid("eda4d57f-784f-45f7-8bf9-a27422fd5174"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("8e8fa93f-737f-41d3-8f73-ba3ab2dc19fb"), new Guid("eda4d57f-784f-45f7-8bf9-a27422fd5174"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("ec93ce23-1823-42ad-8737-bcaa90faa8a4"), new Guid("eda4d57f-784f-45f7-8bf9-a27422fd5174"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("afecbbe3-92f5-4212-8ff0-3c4044c4fdb0"), new Guid("eda4d57f-784f-45f7-8bf9-a27422fd5174"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("d46f227b-e5f7-4b35-82f9-ebd6a9da4a04"), new Guid("33565a3c-49c3-479b-b878-9adc33216f9e"), "LogTech G12", 1000.0, 0 },
                    { new Guid("e4f128c7-b6ab-45dd-9fc6-9523b0b5371e"), new Guid("33565a3c-49c3-479b-b878-9adc33216f9e"), "X7", 2000.0, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("79e84cea-0871-408e-91f1-8cde1cf0aeba"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("eaf7221f-fd3d-437c-b6bc-a3341c1b932e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("13f0cd9c-2415-432b-854f-ec4322b21684"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1fd29202-6998-420d-a5de-c8cb52d697eb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("3e184afc-4062-4466-bf6a-8f3f496db2d3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("8e8fa93f-737f-41d3-8f73-ba3ab2dc19fb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("9fbd0a46-c9d8-4ff1-a4a7-27b28f41cbe6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a0594777-f449-49db-b9e4-10e0bd40899e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("afecbbe3-92f5-4212-8ff0-3c4044c4fdb0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d3c2c316-f108-4bf1-9c00-2815327f2de8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d46f227b-e5f7-4b35-82f9-ebd6a9da4a04"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("e4f128c7-b6ab-45dd-9fc6-9523b0b5371e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("ec93ce23-1823-42ad-8737-bcaa90faa8a4"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("0db888e8-6adb-4479-89de-322b4cb91448"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("0ec0c84a-bae8-4a6b-abd6-c2a2695a43b0"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("2b3e0698-84b1-4378-8f30-83ab96e3f934"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("2d7acfcf-f152-44f2-aea9-91f63779b1ec"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("3c23cff3-612f-4c2b-9481-de07fda9a6bb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("33565a3c-49c3-479b-b878-9adc33216f9e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("eda4d57f-784f-45f7-8bf9-a27422fd5174"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: new Guid("339c2339-26b2-484e-98ea-3d28b16149c2"));

            migrationBuilder.DeleteData(
                table: "Malls",
                keyColumn: "MallId",
                keyValue: new Guid("f0c9370e-5a45-47c5-be96-2edd8814a87b"));

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Balance", "Name" },
                values: new object[] { new Guid("e6cae852-129f-4d9e-a832-45c068aa7a60"), 0.0, "John" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Balance", "Name" },
                values: new object[] { new Guid("79c42c02-ce14-43e2-ad0c-ead85c9704f5"), 0.0, "Wil" });

            migrationBuilder.InsertData(
                table: "Malls",
                columns: new[] { "MallId", "Location", "Name" },
                values: new object[] { new Guid("3afa0f14-98ef-4ed4-a96a-ced14c414f88"), "10 Pandora", "Ocean Plaza" });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "PurchaseId", "ClientId", "CreationTime", "ProductId" },
                values: new object[,]
                {
                    { new Guid("fcff767e-cc06-4e4e-91a5-b84ddc659c9b"), new Guid("e6cae852-129f-4d9e-a832-45c068aa7a60"), new DateTimeOffset(new DateTime(2019, 10, 18, 21, 58, 28, 448, DateTimeKind.Unspecified).AddTicks(7755), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7d5dd5d3-2d71-47de-a75c-f28ddc71f602") },
                    { new Guid("89b95ec5-7c71-4659-af50-1fc4927f8e88"), new Guid("e6cae852-129f-4d9e-a832-45c068aa7a60"), new DateTimeOffset(new DateTime(2019, 10, 18, 21, 58, 28, 448, DateTimeKind.Unspecified).AddTicks(9230), new TimeSpan(0, 0, 0, 0, 0)), new Guid("55acc017-e909-44dd-a390-30427b070d5c") },
                    { new Guid("a2230174-ee2f-42fa-9c39-fde2fe09ffe4"), new Guid("e6cae852-129f-4d9e-a832-45c068aa7a60"), new DateTimeOffset(new DateTime(2019, 10, 18, 21, 58, 28, 448, DateTimeKind.Unspecified).AddTicks(9252), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d4e5b838-9737-4f31-9bf1-d311b048480d") },
                    { new Guid("d1504675-611e-4a72-9089-b481f846f6aa"), new Guid("79c42c02-ce14-43e2-ad0c-ead85c9704f5"), new DateTimeOffset(new DateTime(2019, 10, 18, 21, 58, 28, 448, DateTimeKind.Unspecified).AddTicks(9319), new TimeSpan(0, 0, 0, 0, 0)), new Guid("223c59e6-9fdb-4bc2-b66c-b41cd3f7c69e") },
                    { new Guid("1cf4afba-712e-4325-9900-5b6c92ef009e"), new Guid("79c42c02-ce14-43e2-ad0c-ead85c9704f5"), new DateTimeOffset(new DateTime(2019, 10, 18, 21, 58, 28, 448, DateTimeKind.Unspecified).AddTicks(9323), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8baca7be-82bb-4783-867c-4cde41d5bf4e") }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Location", "MallId", "Name", "Profit" },
                values: new object[] { new Guid("f80d0f79-bcf7-41d7-8fed-adbaa9854a27"), "10 Pandora", new Guid("3afa0f14-98ef-4ed4-a96a-ced14c414f88"), "Shields and Weapons", 0.0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "StoreId" },
                values: new object[] { new Guid("769819e5-4392-4f80-9195-10016ee68b43"), 0, new Guid("f80d0f79-bcf7-41d7-8fed-adbaa9854a27") });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "StoreId" },
                values: new object[] { new Guid("6a2244de-2fb2-4280-8b89-f04ddc8de0fd"), 1, new Guid("f80d0f79-bcf7-41d7-8fed-adbaa9854a27") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Name", "Price", "ProductStatus" },
                values: new object[,]
                {
                    { new Guid("7d5dd5d3-2d71-47de-a75c-f28ddc71f602"), new Guid("769819e5-4392-4f80-9195-10016ee68b43"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("55acc017-e909-44dd-a390-30427b070d5c"), new Guid("769819e5-4392-4f80-9195-10016ee68b43"), "HP 450 G2", 30000.0, 0 },
                    { new Guid("d4e5b838-9737-4f31-9bf1-d311b048480d"), new Guid("769819e5-4392-4f80-9195-10016ee68b43"), "HP 450 G3", 40000.0, 0 },
                    { new Guid("14971105-760a-49d6-bc68-c30de6e02e71"), new Guid("769819e5-4392-4f80-9195-10016ee68b43"), "HP 450 G4", 50000.0, 0 },
                    { new Guid("223c59e6-9fdb-4bc2-b66c-b41cd3f7c69e"), new Guid("769819e5-4392-4f80-9195-10016ee68b43"), "HP 850 G5", 60000.0, 0 },
                    { new Guid("ccd9ff91-423e-4f20-a319-4abd11b74432"), new Guid("769819e5-4392-4f80-9195-10016ee68b43"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("d455fca1-756c-4df8-bab8-6bc63c6803ef"), new Guid("769819e5-4392-4f80-9195-10016ee68b43"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("e4ef194c-bace-4b45-9503-65bb11f1c392"), new Guid("769819e5-4392-4f80-9195-10016ee68b43"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("4f5a3548-99c2-4672-8401-23da19d86249"), new Guid("769819e5-4392-4f80-9195-10016ee68b43"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("8baca7be-82bb-4783-867c-4cde41d5bf4e"), new Guid("6a2244de-2fb2-4280-8b89-f04ddc8de0fd"), "LogTech G12", 1000.0, 0 },
                    { new Guid("85bdd2c1-b3bf-4a5d-a7e2-6e38cfc0b01c"), new Guid("6a2244de-2fb2-4280-8b89-f04ddc8de0fd"), "X7", 2000.0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ClientId",
                table: "Purchases",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ClientId",
                table: "Books",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Clients_ClientId",
                table: "Books",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Clients_ClientId",
                table: "Purchases",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
