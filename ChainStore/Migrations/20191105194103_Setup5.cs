using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStore.Migrations
{
    public partial class Setup5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Balance", "Name" },
                values: new object[,]
                {
                    { new Guid("1117b574-3ab4-44e3-95b8-c0302d78b430"), 0.0, "John" },
                    { new Guid("6f48f5b5-b8d0-41e4-8bf0-0a19a8fa8c59"), 0.0, "Wil" }
                });

            migrationBuilder.InsertData(
                table: "Malls",
                columns: new[] { "MallId", "Location", "Name" },
                values: new object[] { new Guid("cd015038-e865-4215-8de3-2507c604b426"), "10 Pandora", "Ocean Plaza" });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "PurchaseId", "ClientId", "CreationTime", "ProductId" },
                values: new object[,]
                {
                    { new Guid("3177ae0d-91d4-4d97-aa86-8795694e27e2"), new Guid("1117b574-3ab4-44e3-95b8-c0302d78b430"), new DateTimeOffset(new DateTime(2019, 11, 5, 19, 41, 3, 66, DateTimeKind.Unspecified).AddTicks(9721), new TimeSpan(0, 0, 0, 0, 0)), new Guid("59b371b1-5cf2-4c62-b9e3-d0b239c4d947") },
                    { new Guid("844a575b-fc1d-4b1e-a80b-9cf9ddd429b0"), new Guid("1117b574-3ab4-44e3-95b8-c0302d78b430"), new DateTimeOffset(new DateTime(2019, 11, 5, 19, 41, 3, 67, DateTimeKind.Unspecified).AddTicks(952), new TimeSpan(0, 0, 0, 0, 0)), new Guid("36a78229-9a1d-46d8-8687-2359fbe024c3") },
                    { new Guid("4ef041e7-358b-40f9-88f2-507b07691143"), new Guid("1117b574-3ab4-44e3-95b8-c0302d78b430"), new DateTimeOffset(new DateTime(2019, 11, 5, 19, 41, 3, 67, DateTimeKind.Unspecified).AddTicks(1143), new TimeSpan(0, 0, 0, 0, 0)), new Guid("462494dd-169b-4450-bcf9-7e60c6217f81") },
                    { new Guid("7a1aa988-b440-4f7e-b824-c135b378e09b"), new Guid("6f48f5b5-b8d0-41e4-8bf0-0a19a8fa8c59"), new DateTimeOffset(new DateTime(2019, 11, 5, 19, 41, 3, 67, DateTimeKind.Unspecified).AddTicks(1172), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5169aa48-ecfa-4feb-8a03-a31d231f2cb4") },
                    { new Guid("096e06bc-5312-4e87-bb12-397802b62897"), new Guid("6f48f5b5-b8d0-41e4-8bf0-0a19a8fa8c59"), new DateTimeOffset(new DateTime(2019, 11, 5, 19, 41, 3, 67, DateTimeKind.Unspecified).AddTicks(1174), new TimeSpan(0, 0, 0, 0, 0)), new Guid("1c58fe85-1ee4-4680-95fb-f50d9cffaec4") }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Location", "MallId", "Name", "Profit" },
                values: new object[] { new Guid("1460aa22-4699-46aa-b55d-74041f33c7cb"), "10 Pandora", new Guid("cd015038-e865-4215-8de3-2507c604b426"), "Shields and Weapons", 0.0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "StoreId" },
                values: new object[] { new Guid("a4a749b5-a07c-4b8d-b8b5-a8aaeb16351f"), 0, new Guid("1460aa22-4699-46aa-b55d-74041f33c7cb") });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "StoreId" },
                values: new object[] { new Guid("317717ba-3501-43a5-82cd-26081e2c573b"), 1, new Guid("1460aa22-4699-46aa-b55d-74041f33c7cb") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Name", "Price", "ProductStatus" },
                values: new object[,]
                {
                    { new Guid("59b371b1-5cf2-4c62-b9e3-d0b239c4d947"), new Guid("a4a749b5-a07c-4b8d-b8b5-a8aaeb16351f"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("36a78229-9a1d-46d8-8687-2359fbe024c3"), new Guid("a4a749b5-a07c-4b8d-b8b5-a8aaeb16351f"), "HP 450 G2", 30000.0, 0 },
                    { new Guid("462494dd-169b-4450-bcf9-7e60c6217f81"), new Guid("a4a749b5-a07c-4b8d-b8b5-a8aaeb16351f"), "HP 450 G3", 40000.0, 0 },
                    { new Guid("7cf32a99-9947-424f-b985-fadbf6372d4d"), new Guid("a4a749b5-a07c-4b8d-b8b5-a8aaeb16351f"), "HP 450 G4", 50000.0, 0 },
                    { new Guid("5169aa48-ecfa-4feb-8a03-a31d231f2cb4"), new Guid("a4a749b5-a07c-4b8d-b8b5-a8aaeb16351f"), "HP 850 G5", 60000.0, 0 },
                    { new Guid("14972c50-a214-4f7a-8a75-ff8f122696cd"), new Guid("a4a749b5-a07c-4b8d-b8b5-a8aaeb16351f"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("a39f3446-3e0c-4f58-b0ca-7663d865032c"), new Guid("a4a749b5-a07c-4b8d-b8b5-a8aaeb16351f"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("5fc5a529-d998-476b-a461-819cb4a99f8a"), new Guid("a4a749b5-a07c-4b8d-b8b5-a8aaeb16351f"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("2a0ffa89-a6a6-4f45-af0e-ad2b23f2da9a"), new Guid("a4a749b5-a07c-4b8d-b8b5-a8aaeb16351f"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("1c58fe85-1ee4-4680-95fb-f50d9cffaec4"), new Guid("317717ba-3501-43a5-82cd-26081e2c573b"), "LogTech G12", 1000.0, 0 },
                    { new Guid("5921392b-4531-4a0a-aa2f-2bb9d28f2eab"), new Guid("317717ba-3501-43a5-82cd-26081e2c573b"), "X7", 2000.0, 0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("1117b574-3ab4-44e3-95b8-c0302d78b430"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("6f48f5b5-b8d0-41e4-8bf0-0a19a8fa8c59"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("14972c50-a214-4f7a-8a75-ff8f122696cd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1c58fe85-1ee4-4680-95fb-f50d9cffaec4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("2a0ffa89-a6a6-4f45-af0e-ad2b23f2da9a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("36a78229-9a1d-46d8-8687-2359fbe024c3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("462494dd-169b-4450-bcf9-7e60c6217f81"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("5169aa48-ecfa-4feb-8a03-a31d231f2cb4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("5921392b-4531-4a0a-aa2f-2bb9d28f2eab"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("59b371b1-5cf2-4c62-b9e3-d0b239c4d947"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("5fc5a529-d998-476b-a461-819cb4a99f8a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("7cf32a99-9947-424f-b985-fadbf6372d4d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a39f3446-3e0c-4f58-b0ca-7663d865032c"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("096e06bc-5312-4e87-bb12-397802b62897"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("3177ae0d-91d4-4d97-aa86-8795694e27e2"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("4ef041e7-358b-40f9-88f2-507b07691143"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("7a1aa988-b440-4f7e-b824-c135b378e09b"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("844a575b-fc1d-4b1e-a80b-9cf9ddd429b0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("317717ba-3501-43a5-82cd-26081e2c573b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("a4a749b5-a07c-4b8d-b8b5-a8aaeb16351f"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: new Guid("1460aa22-4699-46aa-b55d-74041f33c7cb"));

            migrationBuilder.DeleteData(
                table: "Malls",
                keyColumn: "MallId",
                keyValue: new Guid("cd015038-e865-4215-8de3-2507c604b426"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
