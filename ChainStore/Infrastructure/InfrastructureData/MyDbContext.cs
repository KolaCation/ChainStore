using ChainStore.Domain.DomainCore;
using ChainStore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChainStore.Infrastructure.InfrastructureData
{
    public class MyDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ReliableClient> ReliableClients { get; set; }
        public DbSet<VipClient> VipClients { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Mall> Malls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Mall>().HasMany(m => m.Stores).WithOne(st => st.Mall).IsRequired(false);
            modelBuilder.Entity<Store>().HasMany(st => st.Categories).WithOne(cat => cat.Store)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Category>().HasMany(cat => cat.Products).WithOne(pr => pr.Category);
            modelBuilder.Seed();
            
        }
    }
}