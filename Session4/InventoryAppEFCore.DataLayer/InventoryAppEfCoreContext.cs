using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventoryAppEFCore.DataLayer
{
    public class InventoryAppEfCoreContext : DbContext
    {

        public InventoryAppEfCoreContext(DbContextOptions<InventoryAppEfCoreContext> options)
          : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(50);
                entity.Property<DateTime>("LastUpdated");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(s => s.SupplierId);
                entity.Property(s => s.Name).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Tag>().HasKey(t => t.TagId);

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(r => r.ReviewId);
                entity.Property(r => r.ProductId).HasField("_productId");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(c => c.ClientId);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<PriceOffer>().HasKey(po => po.PriceOfferId);

            var utcConverter = new ValueConverter<DateTime, DateTime>(
                toDb => toDb,
                fromDb => DateTime.SpecifyKind(fromDb, DateTimeKind.Utc));

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.OrderId);
                entity.Property(o => o.DateOrderedUtc).HasConversion(utcConverter);
            });
        }

    }
}