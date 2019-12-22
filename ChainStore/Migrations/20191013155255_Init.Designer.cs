﻿// <auto-generated />
using System;
using ChainStore.Infrastructure.InfrastructureData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChainStore.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20191013155255_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChainStore.Domain.Model.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryName")
                        .HasColumnType("int");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoryId");

                    b.HasIndex("StoreId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("268b16f9-d580-406b-82ee-2ca75518f80d"),
                            CategoryName = 0,
                            StoreId = new Guid("3957a423-9d61-49b9-9f94-2cbdc65f678d")
                        },
                        new
                        {
                            CategoryId = new Guid("3ecae22f-4537-4448-bd0c-50878d76fc4c"),
                            CategoryName = 1,
                            StoreId = new Guid("3957a423-9d61-49b9-9f94-2cbdc65f678d")
                        });
                });

            modelBuilder.Entity("ChainStore.Domain.Model.Client", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            ClientId = new Guid("942df19c-69aa-4a82-9a48-5925b5021e28"),
                            Balance = 0.0,
                            Name = "John"
                        },
                        new
                        {
                            ClientId = new Guid("a70b6202-2d33-4816-b0d4-e2a10fd65bfa"),
                            Balance = 0.0,
                            Name = "Wil"
                        });
                });

            modelBuilder.Entity("ChainStore.Domain.Model.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductStatus")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("bfdde67c-babf-40f2-a5bb-118cd8c0bec5"),
                            CategoryId = new Guid("268b16f9-d580-406b-82ee-2ca75518f80d"),
                            Name = "HP 450 G1",
                            Price = 20000.0,
                            ProductStatus = 0
                        },
                        new
                        {
                            ProductId = new Guid("3b0cbece-631e-4e11-9e2e-a686d7ae87a5"),
                            CategoryId = new Guid("268b16f9-d580-406b-82ee-2ca75518f80d"),
                            Name = "HP 450 G2",
                            Price = 30000.0,
                            ProductStatus = 0
                        },
                        new
                        {
                            ProductId = new Guid("80c90ba1-022d-436d-9d99-eb7d60038461"),
                            CategoryId = new Guid("268b16f9-d580-406b-82ee-2ca75518f80d"),
                            Name = "HP 450 G3",
                            Price = 40000.0,
                            ProductStatus = 0
                        },
                        new
                        {
                            ProductId = new Guid("3e0a2251-46ba-4303-8bcc-72ec000ea855"),
                            CategoryId = new Guid("268b16f9-d580-406b-82ee-2ca75518f80d"),
                            Name = "HP 450 G4",
                            Price = 50000.0,
                            ProductStatus = 0
                        },
                        new
                        {
                            ProductId = new Guid("8c2a1f32-276c-47c6-9638-a897d44ac8f5"),
                            CategoryId = new Guid("268b16f9-d580-406b-82ee-2ca75518f80d"),
                            Name = "HP 850 G5",
                            Price = 60000.0,
                            ProductStatus = 0
                        },
                        new
                        {
                            ProductId = new Guid("7def4192-8577-4e04-92ed-448c40999f41"),
                            CategoryId = new Guid("3ecae22f-4537-4448-bd0c-50878d76fc4c"),
                            Name = "LogTech G12",
                            Price = 1000.0,
                            ProductStatus = 0
                        },
                        new
                        {
                            ProductId = new Guid("bf56541d-d56b-4fd5-8073-5b4893d75087"),
                            CategoryId = new Guid("3ecae22f-4537-4448-bd0c-50878d76fc4c"),
                            Name = "X7",
                            Price = 2000.0,
                            ProductStatus = 0
                        });
                });

            modelBuilder.Entity("ChainStore.Domain.Model.Purchase", b =>
                {
                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ClientId", "ProductId");

                    b.ToTable("Purchases");

                    b.HasData(
                        new
                        {
                            ClientId = new Guid("942df19c-69aa-4a82-9a48-5925b5021e28"),
                            ProductId = new Guid("bfdde67c-babf-40f2-a5bb-118cd8c0bec5")
                        },
                        new
                        {
                            ClientId = new Guid("942df19c-69aa-4a82-9a48-5925b5021e28"),
                            ProductId = new Guid("3b0cbece-631e-4e11-9e2e-a686d7ae87a5")
                        },
                        new
                        {
                            ClientId = new Guid("942df19c-69aa-4a82-9a48-5925b5021e28"),
                            ProductId = new Guid("80c90ba1-022d-436d-9d99-eb7d60038461")
                        },
                        new
                        {
                            ClientId = new Guid("a70b6202-2d33-4816-b0d4-e2a10fd65bfa"),
                            ProductId = new Guid("8c2a1f32-276c-47c6-9638-a897d44ac8f5")
                        },
                        new
                        {
                            ClientId = new Guid("a70b6202-2d33-4816-b0d4-e2a10fd65bfa"),
                            ProductId = new Guid("7def4192-8577-4e04-92ed-448c40999f41")
                        });
                });

            modelBuilder.Entity("ChainStore.Domain.Model.Store", b =>
                {
                    b.Property<Guid>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsSubStore")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Profit")
                        .HasColumnType("float");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            StoreId = new Guid("3957a423-9d61-49b9-9f94-2cbdc65f678d"),
                            IsSubStore = false,
                            Location = "10 Pandora",
                            Name = "Shields and Weapons",
                            Profit = 0.0
                        });
                });

            modelBuilder.Entity("ChainStore.Domain.Model.Category", b =>
                {
                    b.HasOne("ChainStore.Domain.Model.Store", "Store")
                        .WithMany("Categories")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChainStore.Domain.Model.Product", b =>
                {
                    b.HasOne("ChainStore.Domain.Model.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChainStore.Domain.Model.Purchase", b =>
                {
                    b.HasOne("ChainStore.Domain.Model.Client", null)
                        .WithMany("Purchases")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
