using ChainStore.Domain.DomainCore;
using Microsoft.EntityFrameworkCore;

namespace ChainStore.Infrastructure.InfrastructureData
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var mall1 = new Mall("Ocean Plaza", "10 Pandora");
            var store1 = new Store("Shields and Weapons", "10 Pandora", mall1.MallId); 
            store1.MoveToMall(mall1.MallId, mall1.Location);
            var category1 = new Category(CategoryNames.Laptop, store1.StoreId);
            var category2 = new Category(CategoryNames.Mouse, store1.StoreId);
            var product1 = new Product("HP 450 G1", 20_000, ProductStatus.OnSale, category1.CategoryId);
            var product11 = new Product("HP 450 G1", 20_000, ProductStatus.OnSale, category1.CategoryId);
            var product111 = new Product("HP 450 G1", 20_000, ProductStatus.OnSale, category1.CategoryId);
            var product1111 = new Product("HP 450 G1", 20_000, ProductStatus.OnSale, category1.CategoryId);
            var product11111 = new Product("HP 450 G1", 20_000, ProductStatus.OnSale, category1.CategoryId);
            var product2 = new Product("HP 450 G2", 30_000, ProductStatus.OnSale, category1.CategoryId);
            var product3 = new Product("HP 450 G3", 40_000, ProductStatus.OnSale, category1.CategoryId);
            var product4 = new Product("HP 450 G4", 50_000, ProductStatus.OnSale, category1.CategoryId);
            var product5 = new Product("HP 850 G5", 60_000, ProductStatus.OnSale, category1.CategoryId);
            var product6 = new Product("LogTech G12", 1000, ProductStatus.OnSale, category2.CategoryId);
            var product7 = new Product("X7", 2000, ProductStatus.OnSale, category2.CategoryId);


            modelBuilder.Entity<Product>().HasData(
                product1, product2, product3, product4, product5, product6, product7, product11, product111, product1111, product11111
            );

            modelBuilder.Entity<Category>().HasData(
                category1, category2
            );

            modelBuilder.Entity<Mall>().HasData(
                mall1
                );

            modelBuilder.Entity<Store>().HasData(
                store1
            );
        }
    }
}