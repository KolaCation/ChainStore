using System;
using ChainStore.DataAccessLayerImpl.DbModels;
using ChainStore.Domain.DomainCore;
using Microsoft.EntityFrameworkCore;

namespace ChainStore.DataAccessLayerImpl
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var mall1 = new MallDbModel(Guid.NewGuid(),"Ocean Plaza", "10 Pandora");
            var store1 = new StoreDbModel(Guid.NewGuid(),"Shields and Weapons", "10 Pandora",  mall1.MallDbModelId, 0);
            var category1 = new CategoryDbModel(Guid.NewGuid(), CategoryNames.Laptop, store1.StoreDbModelId);
            var category2 = new CategoryDbModel(Guid.NewGuid(), CategoryNames.Mouse, store1.StoreDbModelId);
            var product1 = new ProductDbModel(Guid.NewGuid(),"HP 450 G1", 20_000, ProductStatus.OnSale, category1.CategoryDbModelId);
            var product11 = new ProductDbModel(Guid.NewGuid(), "HP 450 G1", 20_000, ProductStatus.OnSale, category1.CategoryDbModelId);
            var product111 = new ProductDbModel(Guid.NewGuid(), "HP 450 G1", 20_000, ProductStatus.OnSale, category1.CategoryDbModelId);
            var product1111 = new ProductDbModel(Guid.NewGuid(), "HP 450 G1", 20_000, ProductStatus.OnSale, category1.CategoryDbModelId);
            var product11111 = new ProductDbModel(Guid.NewGuid(), "HP 450 G1", 20_000, ProductStatus.OnSale, category1.CategoryDbModelId);
            var product2 = new ProductDbModel(Guid.NewGuid(), "HP 450 G2", 30_000, ProductStatus.OnSale, category1.CategoryDbModelId);
            var product3 = new ProductDbModel(Guid.NewGuid(), "HP 450 G3", 40_000, ProductStatus.OnSale, category1.CategoryDbModelId);
            var product4 = new ProductDbModel(Guid.NewGuid(), "HP 450 G4", 50_000, ProductStatus.OnSale, category1.CategoryDbModelId);
            var product5 = new ProductDbModel(Guid.NewGuid(), "HP 850 G5", 60_000, ProductStatus.OnSale, category1.CategoryDbModelId);
            var product6 = new ProductDbModel(Guid.NewGuid(), "LogTech G12", 1000, ProductStatus.OnSale, category2.CategoryDbModelId);
            var product7 = new ProductDbModel(Guid.NewGuid(), "X7", 2000, ProductStatus.OnSale, category2.CategoryDbModelId);


            modelBuilder.Entity<ProductDbModel>().HasData(
                product1, product2, product3, product4, product5, product6, product7, product11, product111, product1111, product11111
            );

            modelBuilder.Entity<CategoryDbModel>().HasData(
                category1, category2
            );

            modelBuilder.Entity<MallDbModel>().HasData(
                mall1
                );

            modelBuilder.Entity<StoreDbModel>().HasData(
                store1
            );
        }
    }
}