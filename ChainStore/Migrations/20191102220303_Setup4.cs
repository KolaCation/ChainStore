using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStore.Migrations
{
    public partial class Setup4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Balance", "Name" },
                values: new object[,]
                {
                    { new Guid("e495424a-c58d-447d-93e1-4a6a97cfac2b"), 0.0, "John" },
                    { new Guid("e7fe3531-125c-4e20-9e1c-ed8768d92b2f"), 0.0, "Wil" }
                });

            migrationBuilder.InsertData(
                table: "Malls",
                columns: new[] { "MallId", "Location", "Name" },
                values: new object[] { new Guid("85fb732a-9cd4-4658-8957-238841352ac9"), "10 Pandora", "Ocean Plaza" });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "PurchaseId", "ClientId", "CreationTime", "ProductId" },
                values: new object[,]
                {
                    { new Guid("231f40f8-7072-42d5-be0f-194247e8051e"), new Guid("e495424a-c58d-447d-93e1-4a6a97cfac2b"), new DateTimeOffset(new DateTime(2019, 11, 2, 22, 3, 3, 201, DateTimeKind.Unspecified).AddTicks(6174), new TimeSpan(0, 0, 0, 0, 0)), new Guid("6fd08034-fff9-4e7b-9eb8-47eced85f06f") },
                    { new Guid("bdd5abd7-f86e-424d-8928-99537b4608e0"), new Guid("e495424a-c58d-447d-93e1-4a6a97cfac2b"), new DateTimeOffset(new DateTime(2019, 11, 2, 22, 3, 3, 201, DateTimeKind.Unspecified).AddTicks(7860), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8ed94796-66be-4803-b6ab-d084ec9e6689") },
                    { new Guid("ea9ac509-6267-4da8-93f7-a2eb29914b1c"), new Guid("e495424a-c58d-447d-93e1-4a6a97cfac2b"), new DateTimeOffset(new DateTime(2019, 11, 2, 22, 3, 3, 201, DateTimeKind.Unspecified).AddTicks(7911), new TimeSpan(0, 0, 0, 0, 0)), new Guid("79151e83-fe64-41b9-9307-e54a8c337864") },
                    { new Guid("4018537e-6563-4a41-915d-b6b196ca3b54"), new Guid("e7fe3531-125c-4e20-9e1c-ed8768d92b2f"), new DateTimeOffset(new DateTime(2019, 11, 2, 22, 3, 3, 201, DateTimeKind.Unspecified).AddTicks(7960), new TimeSpan(0, 0, 0, 0, 0)), new Guid("9fc54f44-f30b-47b9-b1fc-342967d0401e") },
                    { new Guid("4850799d-9d20-4033-a7e3-0ed1ce1dfd7e"), new Guid("e7fe3531-125c-4e20-9e1c-ed8768d92b2f"), new DateTimeOffset(new DateTime(2019, 11, 2, 22, 3, 3, 201, DateTimeKind.Unspecified).AddTicks(7963), new TimeSpan(0, 0, 0, 0, 0)), new Guid("e7715a79-775e-4c25-b23d-f3346098a8b5") }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Location", "MallId", "Name", "Profit" },
                values: new object[] { new Guid("852b165a-82ae-49f5-ab6c-76a01ee8f467"), "10 Pandora", new Guid("85fb732a-9cd4-4658-8957-238841352ac9"), "Shields and Weapons", 0.0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "StoreId" },
                values: new object[] { new Guid("caa50ff0-f7de-4871-b401-670f447f1080"), 0, new Guid("852b165a-82ae-49f5-ab6c-76a01ee8f467") });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "StoreId" },
                values: new object[] { new Guid("c0e94f79-c622-4808-9448-dd4a96c5e55e"), 1, new Guid("852b165a-82ae-49f5-ab6c-76a01ee8f467") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Name", "Price", "ProductStatus" },
                values: new object[,]
                {
                    { new Guid("6fd08034-fff9-4e7b-9eb8-47eced85f06f"), new Guid("caa50ff0-f7de-4871-b401-670f447f1080"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("8ed94796-66be-4803-b6ab-d084ec9e6689"), new Guid("caa50ff0-f7de-4871-b401-670f447f1080"), "HP 450 G2", 30000.0, 0 },
                    { new Guid("79151e83-fe64-41b9-9307-e54a8c337864"), new Guid("caa50ff0-f7de-4871-b401-670f447f1080"), "HP 450 G3", 40000.0, 0 },
                    { new Guid("c4071097-fd27-4b9f-941e-c0eb17a70889"), new Guid("caa50ff0-f7de-4871-b401-670f447f1080"), "HP 450 G4", 50000.0, 0 },
                    { new Guid("9fc54f44-f30b-47b9-b1fc-342967d0401e"), new Guid("caa50ff0-f7de-4871-b401-670f447f1080"), "HP 850 G5", 60000.0, 0 },
                    { new Guid("b46f2de0-42d4-4c98-9125-f2dd2837ddf6"), new Guid("caa50ff0-f7de-4871-b401-670f447f1080"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("d8caa76b-99f6-481b-ad3a-434d0b254394"), new Guid("caa50ff0-f7de-4871-b401-670f447f1080"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("5045f31c-b82a-4a7f-af64-c32c3544b8ee"), new Guid("caa50ff0-f7de-4871-b401-670f447f1080"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("1f9365e9-8903-4fdc-b566-f463871d7a65"), new Guid("caa50ff0-f7de-4871-b401-670f447f1080"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("e7715a79-775e-4c25-b23d-f3346098a8b5"), new Guid("c0e94f79-c622-4808-9448-dd4a96c5e55e"), "LogTech G12", 1000.0, 0 },
                    { new Guid("9e661a11-5c10-4b08-a565-e5304f1dbfbc"), new Guid("c0e94f79-c622-4808-9448-dd4a96c5e55e"), "X7", 2000.0, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("e495424a-c58d-447d-93e1-4a6a97cfac2b"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("e7fe3531-125c-4e20-9e1c-ed8768d92b2f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1f9365e9-8903-4fdc-b566-f463871d7a65"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("5045f31c-b82a-4a7f-af64-c32c3544b8ee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("6fd08034-fff9-4e7b-9eb8-47eced85f06f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("79151e83-fe64-41b9-9307-e54a8c337864"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("8ed94796-66be-4803-b6ab-d084ec9e6689"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("9e661a11-5c10-4b08-a565-e5304f1dbfbc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("9fc54f44-f30b-47b9-b1fc-342967d0401e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b46f2de0-42d4-4c98-9125-f2dd2837ddf6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("c4071097-fd27-4b9f-941e-c0eb17a70889"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d8caa76b-99f6-481b-ad3a-434d0b254394"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("e7715a79-775e-4c25-b23d-f3346098a8b5"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("231f40f8-7072-42d5-be0f-194247e8051e"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("4018537e-6563-4a41-915d-b6b196ca3b54"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("4850799d-9d20-4033-a7e3-0ed1ce1dfd7e"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("bdd5abd7-f86e-424d-8928-99537b4608e0"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("ea9ac509-6267-4da8-93f7-a2eb29914b1c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("c0e94f79-c622-4808-9448-dd4a96c5e55e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("caa50ff0-f7de-4871-b401-670f447f1080"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: new Guid("852b165a-82ae-49f5-ab6c-76a01ee8f467"));

            migrationBuilder.DeleteData(
                table: "Malls",
                keyColumn: "MallId",
                keyValue: new Guid("85fb732a-9cd4-4658-8957-238841352ac9"));

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
    }
}
