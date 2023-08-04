using InventoryAppEFCore.DataLayer.EfClasses;
using InventoryAppEFCore.DataLayer.Views;
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
        public DbSet<ClientView> clientViews { get; set; }

        [DbFunction]
        public double? AverageVotes(int clientId) => null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
               new { ClientId = 1, Name = "Client1", IsDeleted = false },
               new { ClientId = 2, Name = "Client2", IsDeleted = false },
               new { ClientId = 3, Name = "Client3", IsDeleted = false },
               new { ClientId = 4, Name = "Client4", IsDeleted = true },
               new { ClientId = 5, Name = "Client5", IsDeleted = true });

            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<ClientView>().ToView("ClientFilterView").HasKey(c => c.ClientId);

            // HasDefaultValue & HasDefaultValueSql
            modelBuilder.Entity<Client>()
                .Property(p => p.DateOfBirth)
                .HasDefaultValue(new DateTime(2023, 1, 1));

            modelBuilder.Entity<Client>()
                .Property(p => p.CreatedOn)
                .HasDefaultValueSql("getutcdate()");

            // Computer Column
            modelBuilder.Entity<Client>()
                .Property(p => p.NameAndCreatedOn)
                .HasComputedColumnSql("[Name] + ',' + [CreatedOn]", stored: true);

            modelBuilder.Entity<Client>()
                .Property(p => p.ComputedBirthYear)
                .HasComputedColumnSql("DatePart(yyyy, [DateOfBirth])");


            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(50);
                entity.Property<DateTime>("LastUpdated");
            });

            // many-to-many relationship between Product and Supplier
            modelBuilder.Entity<Product>()
            .HasMany(p => p.SuppliersLink)
            .WithMany(s => s.ProductsLink)
            .UsingEntity(j => j.ToTable("ProductSupplier"));

            // one-to-one relationship between Product and PriceOffer
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Promotion)
                .WithOne(po => po.Product)
                .HasForeignKey<PriceOffer>(po => po.ProductId);

            // one-to-many relationship between Order and LineItem
            modelBuilder.Entity<Order>()
                .HasMany(o => o.LineItems)
                .WithOne(li => li.Order)
                .HasForeignKey(li => li.OrderId);

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

            modelBuilder.Entity<Client>().HasQueryFilter(c => !c.IsDeleted); //Global Query Filter

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