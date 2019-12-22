using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStore.Migrations
{
    public partial class AddMultipleProductsWithOneName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "Malls",
                keyColumn: "MallId",
                keyValue: new Guid("b5764cc4-b1c3-4ba1-ac04-be3b8bf637ce"));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
