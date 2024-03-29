﻿using ChainStore.DataAccessLayer.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChainStore.DataAccessLayer;

public class MyDbContext : IdentityDbContext<ApplicationUser>
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    internal DbSet<StoreProductDbModel> StoreProductRelation { get; set; }
    internal DbSet<StoreCategoryDbModel> StoreCategoryRelation { get; set; }
    internal DbSet<ProductDbModel> Products { get; set; }
    internal DbSet<CustomerDbModel> Customers { get; set; }
    internal DbSet<ReliableCustomerDbModel> ReliableCustomers { get; set; }
    internal DbSet<VipCustomerDbModel> VipCustomers { get; set; }
    internal DbSet<PurchaseDbModel> Purchases { get; set; }
    internal DbSet<BookDbModel> Books { get; set; }
    internal DbSet<CategoryDbModel> Categories { get; set; }
    internal DbSet<StoreDbModel> Stores { get; set; }
    internal DbSet<MallDbModel> Malls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<StoreProductDbModel>().HasKey(e => new {e.StoreDbModelId, e.ProductDbModelId});
        modelBuilder.Entity<StoreCategoryDbModel>().HasKey(e => new {e.StoreDbModelId, e.CategoryDbModelId});
        modelBuilder.Entity<MallDbModel>().HasMany(m => m.StoreDbModels).WithOne(st => st.MallDbModel)
            .IsRequired(false);
        modelBuilder.Entity<StoreProductDbModel>().HasOne(e => e.StoreDbModel).WithMany(e => e.StoreProductRelation);
        modelBuilder.Entity<StoreProductDbModel>().HasOne(e => e.ProductDbModel).WithMany(e => e.StoreProductRelation);
        modelBuilder.Entity<StoreCategoryDbModel>().HasOne(e => e.StoreDbModel).WithMany(e => e.StoreCategoryRelation);
        modelBuilder.Entity<StoreCategoryDbModel>().HasOne(e => e.CategoryDbModel)
            .WithMany(e => e.StoreCategoryRelation);
        modelBuilder.Entity<CategoryDbModel>().HasMany(cat => cat.ProductDbModels).WithOne(pr => pr.CategoryDbModel);
        modelBuilder.Seed();
    }
}