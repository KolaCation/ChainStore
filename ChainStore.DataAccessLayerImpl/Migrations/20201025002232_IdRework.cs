using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStore.DataAccessLayerImpl.Migrations
{
    public partial class IdRework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Stores_StoreDbModelId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryDbModelId",
                table: "Products");

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

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Malls_MallDbModelId",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stores",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_MallDbModelId",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryDbModelId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Malls",
                table: "Malls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryDbModelId",
                keyValue: new Guid("59752d04-3a1e-4833-9eb9-f0d274da76b0"));

            migrationBuilder.DeleteData(
                table: "StoreCategoryRelation",
                keyColumns: new[] { "StoreDbModelId", "CategoryDbModelId" },
                keyValues: new object[] { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("0b7c1794-ddd8-4fd6-a5a6-68ac9d13f618") });

            migrationBuilder.DeleteData(
                table: "StoreCategoryRelation",
                keyColumns: new[] { "StoreDbModelId", "CategoryDbModelId" },
                keyValues: new object[] { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("bdc0bc96-a4df-40ea-aeb9-199e633c31e0") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("0667a62e-5b5c-4d92-b569-fa9a1e4f4077") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("10868013-4ed5-4a89-8b00-7c662e44cfd7") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("3dfa0460-37f0-4892-9715-770e596391eb") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("485e099d-10bb-406f-8394-0333d22421d1") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("8bee4fd0-8716-4f52-8069-2a1fd66978a1") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("96fbdc34-e7df-408b-8c70-9bd99c3d855d") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("b29787ec-7169-4d27-83aa-238388a582a7") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("b3cb63d7-83ce-4de5-a137-c98e8f3feaed") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("bd3686c9-13a8-47a6-a33c-9d8794eda51b") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("c0a047de-d55c-4199-aa7e-68f4d6c4073a") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"), new Guid("e05d35c8-f8b7-48c5-9e13-2d4b59b2d73e") });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("0667a62e-5b5c-4d92-b569-fa9a1e4f4077"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("10868013-4ed5-4a89-8b00-7c662e44cfd7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("3dfa0460-37f0-4892-9715-770e596391eb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("485e099d-10bb-406f-8394-0333d22421d1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("8bee4fd0-8716-4f52-8069-2a1fd66978a1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("96fbdc34-e7df-408b-8c70-9bd99c3d855d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("b29787ec-7169-4d27-83aa-238388a582a7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("b3cb63d7-83ce-4de5-a137-c98e8f3feaed"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("bd3686c9-13a8-47a6-a33c-9d8794eda51b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("c0a047de-d55c-4199-aa7e-68f4d6c4073a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductDbModelId",
                keyValue: new Guid("e05d35c8-f8b7-48c5-9e13-2d4b59b2d73e"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreDbModelId",
                keyValue: new Guid("98edc982-8f27-4bbc-b531-2a0e37a6459a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryDbModelId",
                keyValue: new Guid("0b7c1794-ddd8-4fd6-a5a6-68ac9d13f618"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryDbModelId",
                keyValue: new Guid("bdc0bc96-a4df-40ea-aeb9-199e633c31e0"));

            migrationBuilder.DeleteData(
                table: "Malls",
                keyColumn: "MallDbModelId",
                keyValue: new Guid("57817fa9-88dc-4c4e-abb2-26e0b1d2ed9a"));

            migrationBuilder.DropColumn(
                name: "StoreDbModelId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "MallDbModelId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "PurchaseDbModelId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "ClientDbModelId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "ProductDbModelId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "ProductDbModelId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryDbModelId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MallDbModelId",
                table: "Malls");

            migrationBuilder.DropColumn(
                name: "ClientDbModelId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CategoryDbModelId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "BookDbModelId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ClientDbModelId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ProductDbModelId",
                table: "Books");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Stores",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MallId",
                table: "Stores",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Purchases",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Purchases",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "PriceAtPurchaseMoment",
                table: "Purchases",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Purchases",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Products",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Products",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Malls",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Clients",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Categories",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Books",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Books",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Books",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stores",
                table: "Stores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Malls",
                table: "Malls",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "StoreDbModelId" },
                values: new object[,]
                {
                    { new Guid("abe915e8-e84c-46cc-83a7-ba5dee415768"), "Laptop", null },
                    { new Guid("edc3c4d0-b53f-4538-ae3e-edb18ee22430"), "Mouse", null },
                    { new Guid("3151b166-837b-4c04-b8d8-7d478a4b6b9b"), "USB", null }
                });

            migrationBuilder.InsertData(
                table: "Malls",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[] { new Guid("9c1d5b26-d398-44d0-87fa-838dc45028f1"), "10 Pandora Street", "Ocean Plaza" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "PriceInUAH", "ProductStatus" },
                values: new object[,]
                {
                    { new Guid("57042385-800e-42ff-b197-faac94f79a6b"), new Guid("abe915e8-e84c-46cc-83a7-ba5dee415768"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("162121d0-2ca7-429f-92ea-0cbc814f1c08"), new Guid("abe915e8-e84c-46cc-83a7-ba5dee415768"), "HP 450 G2", 30000.0, 0 },
                    { new Guid("512f3ad8-b3b2-4d0a-8c2c-53944af85656"), new Guid("abe915e8-e84c-46cc-83a7-ba5dee415768"), "HP 450 G3", 40000.0, 0 },
                    { new Guid("45a2a0ab-5e24-47ce-8bb1-c0d1ca804bc6"), new Guid("abe915e8-e84c-46cc-83a7-ba5dee415768"), "HP 450 G4", 50000.0, 0 },
                    { new Guid("fae7ed00-ca83-4b2c-a236-f992a8a13191"), new Guid("abe915e8-e84c-46cc-83a7-ba5dee415768"), "HP 850 G5", 60000.0, 0 },
                    { new Guid("19d11ccf-0e55-43b0-a0db-d1717ed152c9"), new Guid("abe915e8-e84c-46cc-83a7-ba5dee415768"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("77451d49-5f1b-4053-a502-1f6c3fa907ba"), new Guid("abe915e8-e84c-46cc-83a7-ba5dee415768"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("9456a73e-4c38-4079-ba21-e57abfd436f5"), new Guid("abe915e8-e84c-46cc-83a7-ba5dee415768"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("a52ff1e9-52db-4188-bae5-d684b5b8e4ef"), new Guid("abe915e8-e84c-46cc-83a7-ba5dee415768"), "HP 450 G1", 20000.0, 0 },
                    { new Guid("042616f7-1f8b-43a0-b322-96559c2980fe"), new Guid("edc3c4d0-b53f-4538-ae3e-edb18ee22430"), "LogTech G12", 1000.0, 0 },
                    { new Guid("c51445e0-81f7-413a-b551-a1b7df501cdb"), new Guid("edc3c4d0-b53f-4538-ae3e-edb18ee22430"), "X7", 2000.0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Location", "MallId", "Name", "Profit" },
                values: new object[] { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), "10 Pandora Street", new Guid("9c1d5b26-d398-44d0-87fa-838dc45028f1"), "Shields and Weapons", 0.0 });

            migrationBuilder.InsertData(
                table: "StoreCategoryRelation",
                columns: new[] { "StoreDbModelId", "CategoryDbModelId" },
                values: new object[,]
                {
                    { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("abe915e8-e84c-46cc-83a7-ba5dee415768") },
                    { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("edc3c4d0-b53f-4538-ae3e-edb18ee22430") }
                });

            migrationBuilder.InsertData(
                table: "StoreProductRelation",
                columns: new[] { "StoreDbModelId", "ProductDbModelId" },
                values: new object[,]
                {
                    { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("57042385-800e-42ff-b197-faac94f79a6b") },
                    { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("19d11ccf-0e55-43b0-a0db-d1717ed152c9") },
                    { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("77451d49-5f1b-4053-a502-1f6c3fa907ba") },
                    { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("9456a73e-4c38-4079-ba21-e57abfd436f5") },
                    { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("a52ff1e9-52db-4188-bae5-d684b5b8e4ef") },
                    { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("162121d0-2ca7-429f-92ea-0cbc814f1c08") },
                    { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("512f3ad8-b3b2-4d0a-8c2c-53944af85656") },
                    { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("45a2a0ab-5e24-47ce-8bb1-c0d1ca804bc6") },
                    { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("fae7ed00-ca83-4b2c-a236-f992a8a13191") },
                    { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("042616f7-1f8b-43a0-b322-96559c2980fe") },
                    { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("c51445e0-81f7-413a-b551-a1b7df501cdb") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_MallId",
                table: "Stores",
                column: "MallId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Stores_StoreDbModelId",
                table: "Categories",
                column: "StoreDbModelId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreCategoryRelation_Categories_CategoryDbModelId",
                table: "StoreCategoryRelation",
                column: "CategoryDbModelId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreCategoryRelation_Stores_StoreDbModelId",
                table: "StoreCategoryRelation",
                column: "StoreDbModelId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreProductRelation_Products_ProductDbModelId",
                table: "StoreProductRelation",
                column: "ProductDbModelId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreProductRelation_Stores_StoreDbModelId",
                table: "StoreProductRelation",
                column: "StoreDbModelId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Malls_MallId",
                table: "Stores",
                column: "MallId",
                principalTable: "Malls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Stores_StoreDbModelId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

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

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Malls_MallId",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stores",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_MallId",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Malls",
                table: "Malls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3151b166-837b-4c04-b8d8-7d478a4b6b9b"));

            migrationBuilder.DeleteData(
                table: "StoreCategoryRelation",
                keyColumns: new[] { "StoreDbModelId", "CategoryDbModelId" },
                keyValues: new object[] { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("abe915e8-e84c-46cc-83a7-ba5dee415768") });

            migrationBuilder.DeleteData(
                table: "StoreCategoryRelation",
                keyColumns: new[] { "StoreDbModelId", "CategoryDbModelId" },
                keyValues: new object[] { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("edc3c4d0-b53f-4538-ae3e-edb18ee22430") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("042616f7-1f8b-43a0-b322-96559c2980fe") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("162121d0-2ca7-429f-92ea-0cbc814f1c08") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("19d11ccf-0e55-43b0-a0db-d1717ed152c9") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("45a2a0ab-5e24-47ce-8bb1-c0d1ca804bc6") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("512f3ad8-b3b2-4d0a-8c2c-53944af85656") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("57042385-800e-42ff-b197-faac94f79a6b") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("77451d49-5f1b-4053-a502-1f6c3fa907ba") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("9456a73e-4c38-4079-ba21-e57abfd436f5") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("a52ff1e9-52db-4188-bae5-d684b5b8e4ef") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("c51445e0-81f7-413a-b551-a1b7df501cdb") });

            migrationBuilder.DeleteData(
                table: "StoreProductRelation",
                keyColumns: new[] { "StoreDbModelId", "ProductDbModelId" },
                keyValues: new object[] { new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"), new Guid("fae7ed00-ca83-4b2c-a236-f992a8a13191") });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("042616f7-1f8b-43a0-b322-96559c2980fe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("162121d0-2ca7-429f-92ea-0cbc814f1c08"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("19d11ccf-0e55-43b0-a0db-d1717ed152c9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("45a2a0ab-5e24-47ce-8bb1-c0d1ca804bc6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("512f3ad8-b3b2-4d0a-8c2c-53944af85656"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("57042385-800e-42ff-b197-faac94f79a6b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("77451d49-5f1b-4053-a502-1f6c3fa907ba"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9456a73e-4c38-4079-ba21-e57abfd436f5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a52ff1e9-52db-4188-bae5-d684b5b8e4ef"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c51445e0-81f7-413a-b551-a1b7df501cdb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fae7ed00-ca83-4b2c-a236-f992a8a13191"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("116d45fc-8bce-4d86-8030-879b8b4cf8c9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("abe915e8-e84c-46cc-83a7-ba5dee415768"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("edc3c4d0-b53f-4538-ae3e-edb18ee22430"));

            migrationBuilder.DeleteData(
                table: "Malls",
                keyColumn: "Id",
                keyValue: new Guid("9c1d5b26-d398-44d0-87fa-838dc45028f1"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "MallId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "PriceAtPurchaseMoment",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Malls");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Books");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreDbModelId",
                table: "Stores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MallDbModelId",
                table: "Stores",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PurchaseDbModelId",
                table: "Purchases",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClientDbModelId",
                table: "Purchases",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductDbModelId",
                table: "Purchases",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductDbModelId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryDbModelId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MallDbModelId",
                table: "Malls",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClientDbModelId",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryDbModelId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BookDbModelId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClientDbModelId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductDbModelId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stores",
                table: "Stores",
                column: "StoreDbModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                column: "PurchaseDbModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductDbModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Malls",
                table: "Malls",
                column: "MallDbModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "ClientDbModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryDbModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "BookDbModelId");

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
                name: "IX_Stores_MallDbModelId",
                table: "Stores",
                column: "MallDbModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryDbModelId",
                table: "Products",
                column: "CategoryDbModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Stores_StoreDbModelId",
                table: "Categories",
                column: "StoreDbModelId",
                principalTable: "Stores",
                principalColumn: "StoreDbModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryDbModelId",
                table: "Products",
                column: "CategoryDbModelId",
                principalTable: "Categories",
                principalColumn: "CategoryDbModelId",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Malls_MallDbModelId",
                table: "Stores",
                column: "MallDbModelId",
                principalTable: "Malls",
                principalColumn: "MallDbModelId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
