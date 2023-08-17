using ExpenseTracker.Data;

namespace ExpenseTracker.Tests
{
    public static class TestDatabaseSetup
    {
        public static void SeedData(this ExpenseTrackerDBContext dbContext)
        {
            dbContext.Expenses.AddRange(ExpenseTrackerTestData.ExpenseData());
            dbContext.SaveChanges();
        }

        public static void InitializeDBWithData(this ExpenseTrackerDBContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            dbContext.SeedData();

            dbContext.ChangeTracker.Clear();
        }
    }
}
