using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStore.DataAccessLayerImpl.Migrations
{
    public partial class RenameRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreCategoryDbModels_Categories_CategoryDbModelId",
                table: "StoreCategoryDbModels");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreCategoryDbModels_Stores_StoreDbModelId",
                table: "StoreCategoryDbModels");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreProductDbModels_Products_ProductDbModelId",
                table: "StoreProductDbModels");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreProductDbModels_Stores_StoreDbModelId",
                table: "StoreProductDbModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreProductDbModels",
                table: "StoreProductDbModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreCategoryDbModels",
                table: "StoreCategoryDbModels");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("4f2b7566-f5d3-496e-9549-b9e84e5f9fb4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("78ca4154-a904-48fe-a4c5-fa7e23020729"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("b9d1bdcc-ddf2-4b21-99b6-993773e33432"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("c6ee5f31-3354-448d-b26c-4111406365ec"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("c8d32a25-8039-4852-8164-35fdb1c6a6b5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("c9930aba-d5f2-42a5-a1a8-5893bcaf7e12"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("dc136d9b-a826-433a-8687-acd6dd6141c1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("e6b96cf1-9952-49b7-9148-7492f1f02d76"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("f0228d9a-2050-4e4c-979f-413103c703ae"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("f1e5b4b5-876f-4d1a-be99-a0cff31c055b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("fed28943-0fa6-48c5-9e4a-add9e9040af5"));

            migrationBuilder.DeleteData(
                table: "StoreCategoryDbModels",
                keyColumns: new[] { "StoreId", "CategoryId" },
                keyValues: new object[] { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("79454a4e-76e9-44fd-bf24-01f86fcf5db4") });

            migrationBuilder.DeleteData(
                table: "StoreCategoryDbModels",
                keyColumns: new[] { "StoreId", "CategoryId" },
                keyValues: new object[] { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("dcb0af0c-45e5-400f-b10f-ff4e071ed904") });

            migrationBuilder.DeleteData(
                table: "StoreProductDbModels",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("4f2b7566-f5d3-496e-9549-b9e84e5f9fb4") });

            migrationBuilder.DeleteData(
                table: "StoreProductDbModels",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("78ca4154-a904-48fe-a4c5-fa7e23020729") });

            migrationBuilder.DeleteData(
                table: "StoreProductDbModels",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("b9d1bdcc-ddf2-4b21-99b6-993773e33432") });

            migrationBuilder.DeleteData(
                table: "StoreProductDbModels",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("c6ee5f31-3354-448d-b26c-4111406365ec") });

            migrationBuilder.DeleteData(
                table: "StoreProductDbModels",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("c8d32a25-8039-4852-8164-35fdb1c6a6b5") });

            migrationBuilder.DeleteData(
                table: "StoreProductDbModels",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("c9930aba-d5f2-42a5-a1a8-5893bcaf7e12") });

            migrationBuilder.DeleteData(
                table: "StoreProductDbModels",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("dc136d9b-a826-433a-8687-acd6dd6141c1") });

            migrationBuilder.DeleteData(
                table: "StoreProductDbModels",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("e6b96cf1-9952-49b7-9148-7492f1f02d76") });

            migrationBuilder.DeleteData(
                table: "StoreProductDbModels",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("f0228d9a-2050-4e4c-979f-413103c703ae") });

            migrationBuilder.DeleteData(
                table: "StoreProductDbModels",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("f1e5b4b5-876f-4d1a-be99-a0cff31c055b") });

            migrationBuilder.DeleteData(
                table: "StoreProductDbModels",
                keyColumns: new[] { "StoreId", "ProductId" },
                keyValues: new object[] { new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"), new Guid("fed28943-0fa6-48c5-9e4a-add9e9040af5") });

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreDbModelId",
                keyValue: new Guid("7b3bc365-9bf2-44c5-827f-e88b31b5c7e4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryDbModelId",
                keyValue: new Guid("79454a4e-76e9-44fd-bf24-01f86fcf5db4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryDbModelId",
                keyValue: new Guid("dcb0af0c-45e5-400f-b10f-ff4e071ed904"));

            migrationBuilder.DeleteData(
                table: "Malls",
                keyColumn: "MallDbModelId",
                keyValue: new Guid("c4570f80-3d01-4bb8-bdef-ce87b29c69a6"));

            migrationBuilder.RenameTable(
                name: "StoreProductDbModels",
                newName: "StoreProductRelation");

            migrationBuilder.RenameTable(
                name: "StoreCategoryDbModels",
                newName: "StoreCategoryRelation");

            migrationBuilder.RenameIndex(
                name: "IX_StoreProductDbModels_StoreDbModelId",
                table: "StoreProductRelation",
                newName: "IX_StoreProductRelation_StoreDbModelId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreProductDbModels_ProductDbModelId",
                table: "StoreProductRelation",
                newName: "IX_StoreProductRelation_ProductDbModelId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreCategoryDbModels_StoreDbModelId",
                table: "StoreCategoryRelation",
                newName: "IX_StoreCategoryRelation_StoreDbModelId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreCategoryDbModels_CategoryDbModelId",
                table: "StoreCategoryRelation",
                newName: "IX_StoreCategoryRelation_CategoryDbModelId");

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

            migrationBuilder.RenameTable(
                name: "StoreProductRelation",
                newName: "StoreProductDbModels");

            migrationBuilder.RenameTable(
                name: "StoreCategoryRelation",
                newName: "StoreCategoryDbModels");

            migrationBuilder.RenameIndex(
                name: "IX_StoreProductRelation_StoreDbModelId",
                table: "StoreProductDbModels",
                newName: "IX_StoreProductDbModels_StoreDbModelId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreProductRelation_ProductDbModelId",
                table: "StoreProductDbModels",
                newName: "IX_StoreProductDbModels_ProductDbModelId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreCategoryRelation_StoreDbModelId",
                table: "StoreCategoryDbModels",
                newName: "IX_StoreCategoryDbModels_StoreDbModelId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreCategoryRelation_CategoryDbModelId",
                table: "StoreCategoryDbModels",
                newName: "IX_StoreCategoryDbModels_CategoryDbModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreProductDbModels",
                table: "StoreProductDbModels",
                columns: new[] { "StoreId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreCategoryDbModels",
                table: "StoreCategoryDbModels",
                columns: new[] { "StoreId", "CategoryId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_StoreCategoryDbModels_Categories_CategoryDbModelId",
                table: "StoreCategoryDbModels",
                column: "CategoryDbModelId",
                principalTable: "Categories",
                principalColumn: "CategoryDbModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreCategoryDbModels_Stores_StoreDbModelId",
                table: "StoreCategoryDbModels",
                column: "StoreDbModelId",
                principalTable: "Stores",
                principalColumn: "StoreDbModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreProductDbModels_Products_ProductDbModelId",
                table: "StoreProductDbModels",
                column: "ProductDbModelId",
                principalTable: "Products",
                principalColumn: "ProductDbModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreProductDbModels_Stores_StoreDbModelId",
                table: "StoreProductDbModels",
                column: "StoreDbModelId",
                principalTable: "Stores",
                principalColumn: "StoreDbModelId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
