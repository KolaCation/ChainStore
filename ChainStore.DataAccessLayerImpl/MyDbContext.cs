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
            modelBuilder.Entity<MallDbModel>().HasMany(m => m.StoreDbModels).WithOne(st => st.MallDbModel).IsRequired(false);
            modelBuilder.Entity<StoreDbModel>().HasMany(st => st.CategoryDbModels).WithOne(cat => cat.StoreDbModel)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<CategoryDbModel>().HasMany(cat => cat.ProductDbModels).WithOne(pr => pr.CategoryDbModel);
            modelBuilder.Seed();
            
        }
    }
}