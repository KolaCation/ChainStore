﻿// <auto-generated />
using System;
using ChainStore.DataAccessLayer;
using ChainStore.DataAccessLayerImpl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChainStore.DataAccessLayerImpl.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("CustomerDbModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.BookDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("ExpirationTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ReserveDaysCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.CategoryDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StoreDbModelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StoreDbModelId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"),
                            Name = "Laptop"
                        },
                        new
                        {
                            Id = new Guid("cb454cdf-7b81-4bb3-84b1-a2958a272213"),
                            Name = "Mouse"
                        },
                        new
                        {
                            Id = new Guid("0f798ee0-a067-4c46-9018-76cddb083949"),
                            Name = "USB"
                        });
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.CustomerDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("CustomerDbModel");
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.MallDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Malls");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d51f2f67-ad25-435c-b9fc-20646cb53936"),
                            Location = "10 Pandora Street",
                            Name = "Ocean Plaza"
                        });
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.ProductDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PriceInUAH")
                        .HasColumnType("float");

                    b.Property<int>("ProductStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4cd83e2e-6afa-4436-8e90-8e6a0d00a9c5"),
                            CategoryId = new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"),
                            Name = "HP 450 G1",
                            PriceInUAH = 20000.0,
                            ProductStatus = 0
                        },
                        new
                        {
                            Id = new Guid("cbde0e36-b669-4991-8c21-0def6606ef6f"),
                            CategoryId = new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"),
                            Name = "HP 450 G2",
                            PriceInUAH = 30000.0,
                            ProductStatus = 0
                        },
                        new
                        {
                            Id = new Guid("bd44ac0d-cf07-410c-ab19-7ef9cf220cbd"),
                            CategoryId = new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"),
                            Name = "HP 450 G3",
                            PriceInUAH = 40000.0,
                            ProductStatus = 0
                        },
                        new
                        {
                            Id = new Guid("386a2632-0827-4fac-84fb-9a1baf7b1d56"),
                            CategoryId = new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"),
                            Name = "HP 450 G4",
                            PriceInUAH = 50000.0,
                            ProductStatus = 0
                        },
                        new
                        {
                            Id = new Guid("c34e803f-9c5c-4fae-a2bf-6a935070609c"),
                            CategoryId = new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"),
                            Name = "HP 850 G5",
                            PriceInUAH = 60000.0,
                            ProductStatus = 0
                        },
                        new
                        {
                            Id = new Guid("d7a9084e-6259-4fa2-92ee-6aa24c489d3c"),
                            CategoryId = new Guid("cb454cdf-7b81-4bb3-84b1-a2958a272213"),
                            Name = "LogTech G12",
                            PriceInUAH = 1000.0,
                            ProductStatus = 0
                        },
                        new
                        {
                            Id = new Guid("1c1641b0-9b16-40a6-8ec2-5a63eb26ea0e"),
                            CategoryId = new Guid("cb454cdf-7b81-4bb3-84b1-a2958a272213"),
                            Name = "X7",
                            PriceInUAH = 2000.0,
                            ProductStatus = 0
                        },
                        new
                        {
                            Id = new Guid("99e42cde-7987-4d81-9be9-7777b64bba27"),
                            CategoryId = new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"),
                            Name = "HP 450 G1",
                            PriceInUAH = 20000.0,
                            ProductStatus = 0
                        },
                        new
                        {
                            Id = new Guid("e09ed0c8-ffd3-4b12-9dc8-302be4f94748"),
                            CategoryId = new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"),
                            Name = "HP 450 G1",
                            PriceInUAH = 20000.0,
                            ProductStatus = 0
                        },
                        new
                        {
                            Id = new Guid("5beb03eb-6415-4819-8131-6b6e3ecd0bcf"),
                            CategoryId = new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"),
                            Name = "HP 450 G1",
                            PriceInUAH = 20000.0,
                            ProductStatus = 0
                        },
                        new
                        {
                            Id = new Guid("b1f5345c-61f1-43fe-99c6-1708aea98ce1"),
                            CategoryId = new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686"),
                            Name = "HP 450 G1",
                            PriceInUAH = 20000.0,
                            ProductStatus = 0
                        });
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.PurchaseDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("PriceAtPurchaseMoment")
                        .HasColumnType("float");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.StoreCategoryDbModel", b =>
                {
                    b.Property<Guid>("StoreDbModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryDbModelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StoreDbModelId", "CategoryDbModelId");

                    b.HasIndex("CategoryDbModelId");

                    b.ToTable("StoreCategoryRelation");

                    b.HasData(
                        new
                        {
                            StoreDbModelId = new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0"),
                            CategoryDbModelId = new Guid("61b2baa1-d535-4e42-aef8-40143c6e1686")
                        },
                        new
                        {
                            StoreDbModelId = new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0"),
                            CategoryDbModelId = new Guid("cb454cdf-7b81-4bb3-84b1-a2958a272213")
                        });
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.StoreDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MallId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Profit")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MallId");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0"),
                            Location = "10 Pandora Street",
                            MallId = new Guid("d51f2f67-ad25-435c-b9fc-20646cb53936"),
                            Name = "Shields and Weapons",
                            Profit = 0.0
                        });
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.StoreProductDbModel", b =>
                {
                    b.Property<Guid>("StoreDbModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductDbModelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StoreDbModelId", "ProductDbModelId");

                    b.HasIndex("ProductDbModelId");

                    b.ToTable("StoreProductRelation");

                    b.HasData(
                        new
                        {
                            StoreDbModelId = new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0"),
                            ProductDbModelId = new Guid("4cd83e2e-6afa-4436-8e90-8e6a0d00a9c5")
                        },
                        new
                        {
                            StoreDbModelId = new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0"),
                            ProductDbModelId = new Guid("99e42cde-7987-4d81-9be9-7777b64bba27")
                        },
                        new
                        {
                            StoreDbModelId = new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0"),
                            ProductDbModelId = new Guid("e09ed0c8-ffd3-4b12-9dc8-302be4f94748")
                        },
                        new
                        {
                            StoreDbModelId = new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0"),
                            ProductDbModelId = new Guid("5beb03eb-6415-4819-8131-6b6e3ecd0bcf")
                        },
                        new
                        {
                            StoreDbModelId = new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0"),
                            ProductDbModelId = new Guid("b1f5345c-61f1-43fe-99c6-1708aea98ce1")
                        },
                        new
                        {
                            StoreDbModelId = new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0"),
                            ProductDbModelId = new Guid("cbde0e36-b669-4991-8c21-0def6606ef6f")
                        },
                        new
                        {
                            StoreDbModelId = new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0"),
                            ProductDbModelId = new Guid("bd44ac0d-cf07-410c-ab19-7ef9cf220cbd")
                        },
                        new
                        {
                            StoreDbModelId = new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0"),
                            ProductDbModelId = new Guid("386a2632-0827-4fac-84fb-9a1baf7b1d56")
                        },
                        new
                        {
                            StoreDbModelId = new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0"),
                            ProductDbModelId = new Guid("c34e803f-9c5c-4fae-a2bf-6a935070609c")
                        },
                        new
                        {
                            StoreDbModelId = new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0"),
                            ProductDbModelId = new Guid("d7a9084e-6259-4fa2-92ee-6aa24c489d3c")
                        },
                        new
                        {
                            StoreDbModelId = new Guid("9ef7d7e4-2d68-492e-b09e-a4ed44913ed0"),
                            ProductDbModelId = new Guid("1c1641b0-9b16-40a6-8ec2-5a63eb26ea0e")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.ReliableCustomerDbModel", b =>
                {
                    b.HasBaseType("ChainStore.DataAccessLayerImpl.DbModels.CustomerDbModel");

                    b.Property<double>("CashBack")
                        .HasColumnType("float");

                    b.Property<int>("CashBackPercent")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("ReliableCustomerDbModel");
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.VipCustomerDbModel", b =>
                {
                    b.HasBaseType("ChainStore.DataAccessLayerImpl.DbModels.ReliableCustomerDbModel");

                    b.Property<int>("DiscountPercent")
                        .HasColumnType("int");

                    b.Property<double>("Points")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("VipCustomerDbModel");
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.CategoryDbModel", b =>
                {
                    b.HasOne("ChainStore.DataAccessLayerImpl.DbModels.StoreDbModel", null)
                        .WithMany("CategoryDbModels")
                        .HasForeignKey("StoreDbModelId");
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.ProductDbModel", b =>
                {
                    b.HasOne("ChainStore.DataAccessLayerImpl.DbModels.CategoryDbModel", "CategoryDbModel")
                        .WithMany("ProductDbModels")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryDbModel");
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.StoreCategoryDbModel", b =>
                {
                    b.HasOne("ChainStore.DataAccessLayerImpl.DbModels.CategoryDbModel", "CategoryDbModel")
                        .WithMany("StoreCategoryRelation")
                        .HasForeignKey("CategoryDbModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChainStore.DataAccessLayerImpl.DbModels.StoreDbModel", "StoreDbModel")
                        .WithMany("StoreCategoryRelation")
                        .HasForeignKey("StoreDbModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryDbModel");

                    b.Navigation("StoreDbModel");
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.StoreDbModel", b =>
                {
                    b.HasOne("ChainStore.DataAccessLayerImpl.DbModels.MallDbModel", "MallDbModel")
                        .WithMany("StoreDbModels")
                        .HasForeignKey("MallId");

                    b.Navigation("MallDbModel");
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.StoreProductDbModel", b =>
                {
                    b.HasOne("ChainStore.DataAccessLayerImpl.DbModels.ProductDbModel", "ProductDbModel")
                        .WithMany("StoreProductRelation")
                        .HasForeignKey("ProductDbModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChainStore.DataAccessLayerImpl.DbModels.StoreDbModel", "StoreDbModel")
                        .WithMany("StoreProductRelation")
                        .HasForeignKey("StoreDbModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductDbModel");

                    b.Navigation("StoreDbModel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ChainStore.DataAccessLayerImpl.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ChainStore.DataAccessLayerImpl.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChainStore.DataAccessLayerImpl.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ChainStore.DataAccessLayerImpl.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.CategoryDbModel", b =>
                {
                    b.Navigation("ProductDbModels");

                    b.Navigation("StoreCategoryRelation");
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.MallDbModel", b =>
                {
                    b.Navigation("StoreDbModels");
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.ProductDbModel", b =>
                {
                    b.Navigation("StoreProductRelation");
                });

            modelBuilder.Entity("ChainStore.DataAccessLayerImpl.DbModels.StoreDbModel", b =>
                {
                    b.Navigation("CategoryDbModels");

                    b.Navigation("StoreCategoryRelation");

                    b.Navigation("StoreProductRelation");
                });
#pragma warning restore 612, 618
        }
    }
}
