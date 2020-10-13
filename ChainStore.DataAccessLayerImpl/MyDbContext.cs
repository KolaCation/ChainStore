using ChainStore.DataAccessLayerImpl.DbModels;
using ChainStore.Domain.DomainCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChainStore.DataAccessLayerImpl
{
    public class MyDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        internal DbSet<StoreProductDbModel> StoreProductDbModels { get; set; }
        internal DbSet<StoreCategoryDbModel> StoreCategoryDbModels { get; set; }
        internal DbSet<ProductDbModel> Products { get; set; }
        internal DbSet<ClientDbModel> Clients { get; set; }
        internal DbSet<ReliableClientDbModel> ReliableClients { get; set; }
        internal DbSet<VipClientDbModel> VipClients { get; set; }
        internal DbSet<PurchaseDbModel> Purchases { get; set; }
        internal DbSet<BookDbModel> Books { get; set; }
        internal DbSet<CategoryDbModel> Categories { get; set; }
        internal DbSet<StoreDbModel> Stores { get; set; }
        internal DbSet<MallDbModel> Malls { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StoreProductDbModel>().HasKey(e => new { e.StoreId, e.ProductId });
            modelBuilder.Entity<StoreCategoryDbModel>().HasKey(e => new { e.StoreId, e.CategoryId });
            modelBuilder.Entity<MallDbModel>().HasMany(m => m.StoreDbModels).WithOne(st => st.MallDbModel).IsRequired(false);
            modelBuilder.Entity<StoreProductDbModel>().HasOne(e => e.StoreDbModel).WithMany(e => e.StoreProductRelation);
            modelBuilder.Entity<StoreProductDbModel>().HasOne(e => e.ProductDbModel).WithMany(e => e.StoreProductRelation);
            modelBuilder.Entity<StoreCategoryDbModel>().HasOne(e => e.StoreDbModel).WithMany(e => e.StoreCategoryRelation);
            modelBuilder.Entity<StoreCategoryDbModel>().HasOne(e => e.CategoryDbModel).WithMany(e => e.StoreCategoryRelation);
            modelBuilder.Entity<CategoryDbModel>().HasMany(cat => cat.ProductDbModels).WithOne(pr => pr.CategoryDbModel);
            modelBuilder.Seed();
        }
    }
}