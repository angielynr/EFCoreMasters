using ExpenseTracker.Data;
using ExpenseTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExpenseTracker.Tests.Fixture
{
    public class ExpenseFixture
    {
        object contextLock = new object();
        private static bool _databaseInitialized;

        public IEnumerable<Expense> Expenses { get; }

        public ExpenseFixture()
        {

            #region Setup DB
            lock (contextLock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        //Create up-to-date database
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        //Seed data
                        context.Expenses.AddRange(ExpenseTrackerTestData.ExpenseData());

                        context.SaveChanges();
                    }

                    _databaseInitialized = true;
                }
            }
            #endregion

        }

        public ExpenseTrackerDBContext CreateContext() => new ExpenseTrackerDBContext(
            new DbContextOptionsBuilder<ExpenseTrackerDBContext>().UseSqlServer(GetTestConnectionString()).Options);

        public void CreateCleanDBWithData()
        {
            var expenses = ExpenseTrackerTestData.ExpenseData();
            using (var context = CreateContext())
            {
                //Create up-to-date database
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //Seed data
                context.Expenses.AddRange(expenses);

                context.SaveChanges();
            }
        }

        public void CleanDB()
        {
            using (var context = CreateContext())
            {
                //Create up-to-date database
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
        private string GetTestConnectionString()
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            return config.GetConnectionString("ExpenseTrackerTestDB");
        }
    }
}
