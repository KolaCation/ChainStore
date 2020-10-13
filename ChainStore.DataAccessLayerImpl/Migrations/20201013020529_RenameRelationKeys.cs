using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStore.DataAccessLayerImpl.Migrations
{
    public partial class RenameRelationKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreCategoryRelation_Categories_CategoryDbModelId",
                table: "StoreCategoryRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreCategoryRelation_Stores_StoreDbModelId",
                table: "StoreCategoryRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreProductRelation_Products_ProductDbModelId",
                table: "StoreProductRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreProductRelation_Stores_StoreDbModelId",
                table: "StoreProductRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreProductRelation",
                table: "StoreProductRelation");

            migrationBuilder.DropIndex(
                name: "IX_StoreProductRelation_StoreDbModelId",
                table: "StoreProductRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreCategoryRelation",
                table: "StoreCategoryRelation");

            migrationBuilder.DropIndex(
                name: "IX_StoreCategoryRelation_StoreDbModelId",
                table: "StoreCategoryRelation");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("1ceb241a-3f08-489a-92bb-916ff87a25b8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("56ec95c6-c262-42ab-9111-3eda065c14be"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("76fac325-8433-4172-bd37-507bcc4e374e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("79de990c-c73b-4288-9b3d-6aae9fa6a69d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("8d459304-334d-4ae0-89e4-9036d83b4994"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("af8520ab-6adf-4a38-a1fd-80cf0a902f7b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("b5068df3-c134-4901-9351-a50a76b78cad"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("e1551667-7881-4d3a-b8a7-c91e243c0aef"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("ebc79e64-63a9-4f99-b908-91ee0afeafe0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("fe61be0b-a1f3-408c-bf11-5c27a37e777c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("fe84b363-d3cf-4777-90b2-47e851e7bc89"));

            migrationBuilder.DeleteData(
                table: "StoreCategoryRelation",
                keyColumns: new[] { "StoreId", "CategoryId" },
                keyValues: new object[] { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("3b34ab7c-e39f-4235-a766-5dd99fbe0e57") });

            migrationBuilder.DeleteData(
                table: "StoreCategoryRelation",
                keyColumns: new[] { "StoreId", "CategoryId" },
                keyValues: new object[] { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("70ddd346-f335-4747-b173-921e1e68afe4") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("1ceb241a-3f08-489a-92bb-916ff87a25b8") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("56ec95c6-c262-42ab-9111-3eda065c14be") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("76fac325-8433-4172-bd37-507bcc4e374e") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("79de990c-c73b-4288-9b3d-6aae9fa6a69d") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("8d459304-334d-4ae0-89e4-9036d83b4994") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("af8520ab-6adf-4a38-a1fd-80cf0a902f7b") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("b5068df3-c134-4901-9351-a50a76b78cad") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("e1551667-7881-4d3a-b8a7-c91e243c0aef") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("ebc79e64-63a9-4f99-b908-91ee0afeafe0") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("fe61be0b-a1f3-408c-bf11-5c27a37e777c") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("fe84b363-d3cf-4777-90b2-47e851e7bc89") });

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreDbModelId",
                keyValue: new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryDbModelId",
                keyValue: new Guid("3b34ab7c-e39f-4235-a766-5dd99fbe0e57"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryDbModelId",
                keyValue: new Guid("70ddd346-f335-4747-b173-921e1e68afe4"));

            migrationBuilder.DeleteData(
                table: "Malls",
                keyColumn: "MallDbModelId",
                keyValue: new Guid("e8f3a23f-575d-4999-ba79-0916c9e3d264"));

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "StoreProductRelation");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "StoreProductRelation");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "StoreCategoryRelation");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "StoreCategoryRelation");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreDbModelId",
                table: "StoreProductRelation",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductDbModelId",
                table: "StoreProductRelation",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreDbModelId",
                table: "StoreCategoryRelation",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryDbModelId",
                table: "StoreCategoryRelation",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreProductRelation",
                table: "StoreProductRelation",
                columns: new[] { "StoreDbModelId", "ProductDbModelId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreCategoryRelation",
                table: "StoreCategoryRelation",
                columns: new[] { "StoreDbModelId", "CategoryDbModelId" });

            migrationBuilder.InsertData(
                table: "Malls",
                columns: new[] { "MallDbModelId", "Location", "Name" },
                values: new object[] { new Guid("93db65aa-ba5e-43f0-ac25-3b145e8ca31b"), "10 Pandora Street", "Ocean Plaza" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreDbModelId", "Location", "MallDbModelId", "Name", "Profit" },
                values: new object[] { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), "10 Pandora Street", new Guid("93db65aa-ba5e-43f0-ac25-3b145e8ca31b"), "Shields and Weapons", 0.0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryDbModelId", "Name", "StoreDbModelId" },
                values: new object[] { new Guid("e376db72-02b7-4e86-b0a4-460752468267"), "Laptop", new Guid("a28b221a-98d4-4069-b888-8e423651c64b") });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryDbModelId", "Name", "StoreDbModelId" },
                values: new object[] { new Guid("de0e229b-2a02-41da-88b3-a7bd44309566"), "Mouse", new Guid("a28b221a-98d4-4069-b888-8e423651c64b") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductDbModelId", "CategoryDbModelId", "Name", "PriceInUAH", "ProductStatus" },
                values: new object[,]
                {
                    { new Guid("d886020e-c115-4b51-a3b0-c11ca0a80d7d"), new Guid("e376db72-02b7-4e86-b0a4-460752468267"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("fe4781af-4bd6-4e83-8ea7-8f4c3c79848a"), new Guid("e376db72-02b7-4e86-b0a4-460752468267"), "HP 450 G2", 30000.0, 0 },
                    { new Guid("1215cddc-4da2-4530-a653-e4634009bb1c"), new Guid("e376db72-02b7-4e86-b0a4-460752468267"), "HP 450 G3", 40000.0, 0 },
                    { new Guid("0732ea14-6e25-442d-a3d3-fed4f214a12c"), new Guid("e376db72-02b7-4e86-b0a4-460752468267"), "HP 450 G4", 50000.0, 0 },
                    { new Guid("f549a7b1-9746-44af-a4fa-0a1e4649796b"), new Guid("e376db72-02b7-4e86-b0a4-460752468267"), "HP 850 G5", 60000.0, 0 },
                    { new Guid("7b366602-b480-4c30-a0ef-c17013b4b47c"), new Guid("e376db72-02b7-4e86-b0a4-460752468267"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("5cfffeb8-538b-41cf-963f-f49c4ef97e95"), new Guid("e376db72-02b7-4e86-b0a4-460752468267"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("e76ad929-058a-4c0a-b839-305951890d77"), new Guid("e376db72-02b7-4e86-b0a4-460752468267"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("c874bb95-433c-4ce7-a541-953f5a2db3fe"), new Guid("e376db72-02b7-4e86-b0a4-460752468267"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("22d990e9-b177-49ba-ad83-214a78cfea6a"), new Guid("de0e229b-2a02-41da-88b3-a7bd44309566"), "LogTech G12", 1000.0, 0 },
                    { new Guid("fa10a6a8-364b-4d0a-91a7-15d752f557c0"), new Guid("de0e229b-2a02-41da-88b3-a7bd44309566"), "X7", 2000.0, 0 }
                });

            migrationBuilder.InsertData(
                table: "StoreCategoryRelation",
                columns: new[] { "StoreDbModelId", "CategoryDbModelId" },
                values: new object[,]
                {
                    { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("e376db72-02b7-4e86-b0a4-460752468267") },
                    { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("de0e229b-2a02-41da-88b3-a7bd44309566") }
                });

            migrationBuilder.InsertData(
                table: "StoreProductRelation",
                columns: new[] { "StoreDbModelId", "ProductDbModelId" },
                values: new object[,]
                {
                    { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("d886020e-c115-4b51-a3b0-c11ca0a80d7d") },
                    { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("fe4781af-4bd6-4e83-8ea7-8f4c3c79848a") },
                    { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("1215cddc-4da2-4530-a653-e4634009bb1c") },
                    { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("0732ea14-6e25-442d-a3d3-fed4f214a12c") },
                    { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("f549a7b1-9746-44af-a4fa-0a1e4649796b") },
                    { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("7b366602-b480-4c30-a0ef-c17013b4b47c") },
                    { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("5cfffeb8-538b-41cf-963f-f49c4ef97e95") },
                    { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("e76ad929-058a-4c0a-b839-305951890d77") },
                    { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("c874bb95-433c-4ce7-a541-953f5a2db3fe") },
                    { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("22d990e9-b177-49ba-ad83-214a78cfea6a") },
                    { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("fa10a6a8-364b-4d0a-91a7-15d752f557c0") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StoreCategoryRelation_Categories_CategoryDbModelId",
                table: "StoreCategoryRelation",
                column: "CategoryDbModelId",
                principalTable: "Categories",
                principalColumn: "CategoryDbModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreCategoryRelation_Stores_StoreDbModelId",
                table: "StoreCategoryRelation",
                column: "StoreDbModelId",
                principalTable: "Stores",
                principalColumn: "StoreDbModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreProductRelation_Products_ProductDbModelId",
                table: "StoreProductRelation",
                column: "ProductDbModelId",
                principalTable: "Products",
                principalColumn: "ProductDbModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreProductRelation_Stores_StoreDbModelId",
                table: "StoreProductRelation",
                column: "StoreDbModelId",
                principalTable: "Stores",
                principalColumn: "StoreDbModelId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreCategoryRelation_Categories_CategoryDbModelId",
                table: "StoreCategoryRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreCategoryRelation_Stores_StoreDbModelId",
                table: "StoreCategoryRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreProductRelation_Products_ProductDbModelId",
                table: "StoreProductRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreProductRelation_Stores_StoreDbModelId",
                table: "StoreProductRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreProductRelation",
                table: "StoreProductRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreCategoryRelation",
                table: "StoreCategoryRelation");

            migrationBuilder.DeleteData(
                table: "StoreCategoryRelation",
                keyColumns: new[] { "StoreDbModelId", "CategoryDbModelId" },
                keyValues: new object[] { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("de0e229b-2a02-41da-88b3-a7bd44309566") });

            migrationBuilder.DeleteData(
                table: "StoreCategoryRelation",
                keyColumns: new[] { "StoreDbModelId", "CategoryDbModelId" },
                keyValues: new object[] { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("e376db72-02b7-4e86-b0a4-460752468267") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("0732ea14-6e25-442d-a3d3-fed4f214a12c") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("1215cddc-4da2-4530-a653-e4634009bb1c") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("22d990e9-b177-49ba-ad83-214a78cfea6a") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("5cfffeb8-538b-41cf-963f-f49c4ef97e95") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("7b366602-b480-4c30-a0ef-c17013b4b47c") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("c874bb95-433c-4ce7-a541-953f5a2db3fe") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("d886020e-c115-4b51-a3b0-c11ca0a80d7d") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("e76ad929-058a-4c0a-b839-305951890d77") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("f549a7b1-9746-44af-a4fa-0a1e4649796b") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("fa10a6a8-364b-4d0a-91a7-15d752f557c0") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("a28b221a-98d4-4069-b888-8e423651c64b"), new Guid("fe4781af-4bd6-4e83-8ea7-8f4c3c79848a") });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("0732ea14-6e25-442d-a3d3-fed4f214a12c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("1215cddc-4da2-4530-a653-e4634009bb1c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("22d990e9-b177-49ba-ad83-214a78cfea6a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("5cfffeb8-538b-41cf-963f-f49c4ef97e95"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("7b366602-b480-4c30-a0ef-c17013b4b47c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("c874bb95-433c-4ce7-a541-953f5a2db3fe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("d886020e-c115-4b51-a3b0-c11ca0a80d7d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("e76ad929-058a-4c0a-b839-305951890d77"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("f549a7b1-9746-44af-a4fa-0a1e4649796b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("fa10a6a8-364b-4d0a-91a7-15d752f557c0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("fe4781af-4bd6-4e83-8ea7-8f4c3c79848a"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreDbModelId",
                keyValue: new Guid("a28b221a-98d4-4069-b888-8e423651c64b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryDbModelId",
                keyValue: new Guid("de0e229b-2a02-41da-88b3-a7bd44309566"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryDbModelId",
                keyValue: new Guid("e376db72-02b7-4e86-b0a4-460752468267"));

            migrationBuilder.DeleteData(
                table: "Malls",
                keyColumn: "MallDbModelId",
                keyValue: new Guid("93db65aa-ba5e-43f0-ac25-3b145e8ca31b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductDbModelId",
                table: "StoreProductRelation",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreDbModelId",
                table: "StoreProductRelation",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "StoreProductRelation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "StoreProductRelation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryDbModelId",
                table: "StoreCategoryRelation",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreDbModelId",
                table: "StoreCategoryRelation",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "StoreCategoryRelation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "StoreCategoryRelation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreProductRelation",
                table: "StoreProductRelation",
                columns: new[] { "StoreId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreCategoryRelation",
                table: "StoreCategoryRelation",
                columns: new[] { "StoreId", "CategoryId" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryDbModelId", "Name", "StoreDbModelId" },
                values: new object[,]
                {
                    { new Guid("70ddd346-f335-4747-b173-921e1e68afe4"), "Laptop", null },
                    { new Guid("3b34ab7c-e39f-4235-a766-5dd99fbe0e57"), "Mouse", null }
                });

            migrationBuilder.InsertData(
                table: "Malls",
                columns: new[] { "MallDbModelId", "Location", "Name" },
                values: new object[] { new Guid("e8f3a23f-575d-4999-ba79-0916c9e3d264"), "10 Pandora Street", "Ocean Plaza" });

            migrationBuilder.InsertData(
                table: "StoreCategoryRelation",
                columns: new[] { "StoreId", "CategoryId", "CategoryDbModelId", "StoreDbModelId" },
                values: new object[,]
                {
                    { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("70ddd346-f335-4747-b173-921e1e68afe4"), null, null },
                    { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("3b34ab7c-e39f-4235-a766-5dd99fbe0e57"), null, null }
                });

            migrationBuilder.InsertData(
                table: "StoreProductRelation",
                columns: new[] { "StoreId", "ProductId", "ProductDbModelId", "StoreDbModelId" },
                values: new object[,]
                {
                    { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("b5068df3-c134-4901-9351-a50a76b78cad"), null, null },
                    { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("fe61be0b-a1f3-408c-bf11-5c27a37e777c"), null, null },
                    { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("8d459304-334d-4ae0-89e4-9036d83b4994"), null, null },
                    { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("fe84b363-d3cf-4777-90b2-47e851e7bc89"), null, null },
                    { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("76fac325-8433-4172-bd37-507bcc4e374e"), null, null },
                    { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("ebc79e64-63a9-4f99-b908-91ee0afeafe0"), null, null },
                    { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("af8520ab-6adf-4a38-a1fd-80cf0a902f7b"), null, null },
                    { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("56ec95c6-c262-42ab-9111-3eda065c14be"), null, null },
                    { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("e1551667-7881-4d3a-b8a7-c91e243c0aef"), null, null },
                    { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("79de990c-c73b-4288-9b3d-6aae9fa6a69d"), null, null },
                    { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), new Guid("1ceb241a-3f08-489a-92bb-916ff87a25b8"), null, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductDbModelId", "CategoryDbModelId", "Name", "PriceInUAH", "ProductStatus" },
                values: new object[,]
                {
                    { new Guid("b5068df3-c134-4901-9351-a50a76b78cad"), new Guid("70ddd346-f335-4747-b173-921e1e68afe4"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("ebc79e64-63a9-4f99-b908-91ee0afeafe0"), new Guid("70ddd346-f335-4747-b173-921e1e68afe4"), "HP 450 G2", 30000.0, 0 },
                    { new Guid("af8520ab-6adf-4a38-a1fd-80cf0a902f7b"), new Guid("70ddd346-f335-4747-b173-921e1e68afe4"), "HP 450 G3", 40000.0, 0 },
                    { new Guid("56ec95c6-c262-42ab-9111-3eda065c14be"), new Guid("70ddd346-f335-4747-b173-921e1e68afe4"), "HP 450 G4", 50000.0, 0 },
                    { new Guid("e1551667-7881-4d3a-b8a7-c91e243c0aef"), new Guid("70ddd346-f335-4747-b173-921e1e68afe4"), "HP 850 G5", 60000.0, 0 },
                    { new Guid("fe61be0b-a1f3-408c-bf11-5c27a37e777c"), new Guid("70ddd346-f335-4747-b173-921e1e68afe4"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("8d459304-334d-4ae0-89e4-9036d83b4994"), new Guid("70ddd346-f335-4747-b173-921e1e68afe4"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("fe84b363-d3cf-4777-90b2-47e851e7bc89"), new Guid("70ddd346-f335-4747-b173-921e1e68afe4"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("76fac325-8433-4172-bd37-507bcc4e374e"), new Guid("70ddd346-f335-4747-b173-921e1e68afe4"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("79de990c-c73b-4288-9b3d-6aae9fa6a69d"), new Guid("3b34ab7c-e39f-4235-a766-5dd99fbe0e57"), "LogTech G12", 1000.0, 0 },
                    { new Guid("1ceb241a-3f08-489a-92bb-916ff87a25b8"), new Guid("3b34ab7c-e39f-4235-a766-5dd99fbe0e57"), "X7", 2000.0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreDbModelId", "Location", "MallDbModelId", "Name", "Profit" },
                values: new object[] { new Guid("95932c0a-11d3-455c-ad46-c17434860ffe"), "10 Pandora Street", new Guid("e8f3a23f-575d-4999-ba79-0916c9e3d264"), "Shields and Weapons", 0.0 });

            migrationBuilder.CreateIndex(
                name: "IX_StoreProductRelation_StoreDbModelId",
                table: "StoreProductRelation",
                column: "StoreDbModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreCategoryRelation_StoreDbModelId",
                table: "StoreCategoryRelation",
                column: "StoreDbModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreCategoryRelation_Categories_CategoryDbModelId",
                table: "StoreCategoryRelation",
                column: "CategoryDbModelId",
                principalTable: "Categories",
                principalColumn: "CategoryDbModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreCategoryRelation_Stores_StoreDbModelId",
                table: "StoreCategoryRelation",
                column: "StoreDbModelId",
                principalTable: "Stores",
                principalColumn: "StoreDbModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreProductRelation_Products_ProductDbModelId",
                table: "StoreProductRelation",
                column: "ProductDbModelId",
                principalTable: "Products",
                principalColumn: "ProductDbModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreProductRelation_Stores_StoreDbModelId",
                table: "StoreProductRelation",
                column: "StoreDbModelId",
                principalTable: "Stores",
                principalColumn: "StoreDbModelId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
