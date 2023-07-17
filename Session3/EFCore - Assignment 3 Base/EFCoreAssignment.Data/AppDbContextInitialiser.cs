using EFCoreAssignment.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreAssignment.Data
{
    public class AppDbContextInitialiser
    {
        private readonly ILogger<AppDbContextInitialiser> logger;
        private readonly AppDbContext context;


        public AppDbContextInitialiser(ILogger<AppDbContextInitialiser> logger, AppDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (this.context.Database.IsSqlServer())
                {
                    await this.context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
#pragma warning disable CA1848 // Use the LoggerMessage delegates
                this.logger.LogError(ex, "An error occurred while initializing the database.");
#pragma warning restore CA1848 // Use the LoggerMessage delegates
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await this.TrySeedAsync();
            }
            catch (Exception ex)
            {
#pragma warning disable CA1848 // Use the LoggerMessage delegates
                this.logger.LogError(ex, "An error occurred while seeding the database.");
#pragma warning restore CA1848 // Use the LoggerMessage delegates
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            // Default data
            // Seed, if necessary
            if (!this.context.Shops.Any())
            {
                this.context.Shops.Add(new Shop()
                {
                    Name = "SM Online",
                });

                this.context.Shops.Add(new Shop()
                {
                    Name = "Zalora",
                });

                this.context.Shops.Add(new Shop()
                {
                    Name = "My Shop",
                });

                await this.context.SaveChangesAsync();
            }
        }
    }
}
