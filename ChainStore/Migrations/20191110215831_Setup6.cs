using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStore.Migrations
{
    public partial class Setup6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Stores_StoreId",
                table: "Categories");

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
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Malls",
                columns: new[] { "MallId", "Location", "Name" },
                values: new object[] { new Guid("988508dc-3b9a-4b18-8034-a9db1ac6aec5"), "10 Pandora", "Ocean Plaza" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Location", "MallId", "Name", "Profit" },
                values: new object[] { new Guid("ad4e8179-5ab6-4055-a820-23813d5d8db4"), "10 Pandora", new Guid("988508dc-3b9a-4b18-8034-a9db1ac6aec5"), "Shields and Weapons", 0.0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "StoreId" },
                values: new object[] { new Guid("d2536c24-2614-4fdf-8038-55c1abf9a8f8"), 0, new Guid("ad4e8179-5ab6-4055-a820-23813d5d8db4") });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "StoreId" },
                values: new object[] { new Guid("9170f28d-87e6-4181-a167-cb5d9ebfe84e"), 1, new Guid("ad4e8179-5ab6-4055-a820-23813d5d8db4") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Name", "Price", "ProductStatus" },
                values: new object[,]
                {
                    { new Guid("235220b4-d580-4cdb-bb74-5cbbc9f727a7"), new Guid("d2536c24-2614-4fdf-8038-55c1abf9a8f8"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("9d23c700-7582-4147-aacb-febef73c24a4"), new Guid("d2536c24-2614-4fdf-8038-55c1abf9a8f8"), "HP 450 G2", 30000.0, 0 },
                    { new Guid("666a201f-0fb2-4387-af0f-8685d244788e"), new Guid("d2536c24-2614-4fdf-8038-55c1abf9a8f8"), "HP 450 G3", 40000.0, 0 },
                    { new Guid("298e682a-52d4-4a81-9cb4-6f8395ccb215"), new Guid("d2536c24-2614-4fdf-8038-55c1abf9a8f8"), "HP 450 G4", 50000.0, 0 },
                    { new Guid("5e8b6b58-c57e-4e83-886d-1d3d68a4ebe4"), new Guid("d2536c24-2614-4fdf-8038-55c1abf9a8f8"), "HP 850 G5", 60000.0, 0 },
                    { new Guid("b23fd03b-1023-4cdd-a1fa-6244a64b5697"), new Guid("d2536c24-2614-4fdf-8038-55c1abf9a8f8"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("b1587b2d-3e43-480b-994b-ec5951d3dad0"), new Guid("d2536c24-2614-4fdf-8038-55c1abf9a8f8"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("260c0bcd-6702-4621-be3a-1ed58bafb6ee"), new Guid("d2536c24-2614-4fdf-8038-55c1abf9a8f8"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("64660279-d878-4bed-b939-6da4c2b0ffd8"), new Guid("d2536c24-2614-4fdf-8038-55c1abf9a8f8"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("990d3fb6-49cd-44b4-9046-0fa5c06a5e0e"), new Guid("9170f28d-87e6-4181-a167-cb5d9ebfe84e"), "LogTech G12", 1000.0, 0 },
                    { new Guid("941c98d7-a6db-4b17-aeaf-9c40ab2b38df"), new Guid("9170f28d-87e6-4181-a167-cb5d9ebfe84e"), "X7", 2000.0, 0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Stores_StoreId",
                table: "Categories",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Stores_StoreId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("235220b4-d580-4cdb-bb74-5cbbc9f727a7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("260c0bcd-6702-4621-be3a-1ed58bafb6ee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("298e682a-52d4-4a81-9cb4-6f8395ccb215"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("5e8b6b58-c57e-4e83-886d-1d3d68a4ebe4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("64660279-d878-4bed-b939-6da4c2b0ffd8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("666a201f-0fb2-4387-af0f-8685d244788e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("941c98d7-a6db-4b17-aeaf-9c40ab2b38df"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("990d3fb6-49cd-44b4-9046-0fa5c06a5e0e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("9d23c700-7582-4147-aacb-febef73c24a4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b1587b2d-3e43-480b-994b-ec5951d3dad0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b23fd03b-1023-4cdd-a1fa-6244a64b5697"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("9170f28d-87e6-4181-a167-cb5d9ebfe84e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("d2536c24-2614-4fdf-8038-55c1abf9a8f8"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: new Guid("ad4e8179-5ab6-4055-a820-23813d5d8db4"));

            migrationBuilder.DeleteData(
                table: "Malls",
                keyColumn: "MallId",
                keyValue: new Guid("988508dc-3b9a-4b18-8034-a9db1ac6aec5"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

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
                name: "FK_Categories_Stores_StoreId",
                table: "Categories",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
