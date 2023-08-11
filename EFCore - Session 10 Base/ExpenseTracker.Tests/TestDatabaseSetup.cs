using ExpenseTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //TODO: delete and create a new database
            //TODO: seed data
            
            //TODO: Reset change tracker 
            
        }
    }
}
